using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExampleIXFE_v_3_1
{
    public partial class FormIXFE_v_3_1 : Form
    {
        private const string ClientId = "My Client ID";
        private const string ClientSecret = "My Client Secret";
        // To request a couple of ClientID and ClientSECRET for your team navigate this link: https://www.arxivar.it/it/richiesta-clientid-ixfe-v3

        private string _urlWebApiOAuth = "https://ixapidemo.arxivar.it/oauth/";
        private string _urlWebApiRegistry = "https://ixapidemo.arxivar.it/registry/";
        private string _urlWebApiInvoice = "https://ixapidemo.arxivar.it/invoice/";

        private string _authToken;

        private Guid? _aooIdentifier;
        private string _uoIdentifier;

        public Guid? AooIdentifier
        {
            get { return _aooIdentifier; }
            set
            {
                _aooIdentifier = value;
                LabelAooIdentifier.Text = _aooIdentifier?.ToString();
            }
        }

        public string UoIdentifier
        {
            get { return _uoIdentifier; }
            set
            {
                _uoIdentifier = value;
                LabelUoIdentifier.Text = _uoIdentifier?.ToString();
            }
        }

        public FormIXFE_v_3_1()
        {
            InitializeComponent();

            if (System.IO.File.Exists(@"c:\temp\Ix\UsernameIxFe.txt"))
                textBoxUsernameIxV3.Text = System.IO.File.ReadAllText(@"c:\temp\Ix\UsernameIxFe.txt");
            if (System.IO.File.Exists(@"c:\temp\Ix\PasswordIxFe.txt"))
                textBoxPasswordIxV3.Text = System.IO.File.ReadAllText(@"c:\temp\Ix\PasswordIxFe.txt");
        }

        private void buttonLoginIxV3_Click(object sender, EventArgs e)
        {
            try
            {
                IO.Swagger.Api.AuthorizationApi authorizationApi = new IO.Swagger.Api.AuthorizationApi(_urlWebApiOAuth);
                try
                {
                    var tokenResult = authorizationApi.Token(new IO.Swagger.Model.TokenRequest(ClientId, ClientSecret, IO.Swagger.Model.TokenRequest.GrantTypeEnum.Password, textBoxUsernameIxV3.Text, textBoxPasswordIxV3.Text, null, null, "1.0"));
                    _authToken = tokenResult.AccessToken;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during login: " + ex.ToString());
                }
                tabControl1.Enabled = true;
                // If the connection is established correctly I load the aoo collection
                LoadAooIxFe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Esito Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAooIxFe()
        {
            IO.Swagger.Api.AoosApi aoosApi = new IO.Swagger.Api.AoosApi(_urlWebApiRegistry);
            var aooCollection = aoosApi.Aoos(_authToken).Aoos;

            comboBoxAooIx.DisplayMember = "Name";
            comboBoxAooIx.ValueMember = "Identifier";
            comboBoxAooIx.DataSource = aooCollection;
        }

        private void comboBoxAooIx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAooIx.SelectedIndex < 0)
            {
                AooIdentifier = null;
                return;
            }

            AooIdentifier = ((IO.Swagger.Model.AooInfo)comboBoxAooIx.SelectedItem).Identifier;
            LoadUoIxFe();
        }

        private void LoadUoIxFe()
        {
            if (AooIdentifier != null)
            {
                IO.Swagger.Api.AoosApi aoosApi = new IO.Swagger.Api.AoosApi(_urlWebApiRegistry);
                var uoCollection = aoosApi.AooUos(AooIdentifier, _authToken).AooUos;
                comboBoxUo.DisplayMember = "Name";
                comboBoxUo.ValueMember = "Identifier";
                comboBoxUo.DataSource = uoCollection;
            }
        }

        private void comboBoxUo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUo.SelectedIndex < 0)
            {
                UoIdentifier = null;
                return;
            }

            UoIdentifier = ((IO.Swagger.Model.AooUoInfo)comboBoxUo.SelectedItem).Identifier;
        }

        public void SaveStream(Stream input, string destPath)
        {
            try
            {
                using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[16 * 1024];
                    int bytesRead;

                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLog("Active cycle - Read without offset - Start");

            try
            {
                IO.Swagger.Api.TransmissionInvoicesNotificationsApi transmissionInvoicesNotificationsApi = new IO.Swagger.Api.TransmissionInvoicesNotificationsApi(_urlWebApiInvoice);

                //I create a new subscription
                var transmissionSubscribeResponse = transmissionInvoicesNotificationsApi.TransmissionSubscribe(AooIdentifier, UoIdentifier, _authToken);

                //I download from IX FE the next list of top 10 events
                var transmissionNotificationsResponse = transmissionInvoicesNotificationsApi.GetTransmissionNotifications(AooIdentifier, UoIdentifier, transmissionSubscribeResponse.SubscriptionUID, 10, _authToken);
                foreach (var notification in transmissionNotificationsResponse.Notifications)
                {
                    //foreac event I must manage the event's detail
                    MenageActiveEvent(notification);
                }
                //I call the ACK method
                transmissionInvoicesNotificationsApi.TransmissionSubscriptionAck(AooIdentifier, UoIdentifier, transmissionSubscribeResponse.SubscriptionUID, transmissionNotificationsResponse.AckUID, _authToken);

                //Now I call the Commit method. If you prefer you can cycle and call next the couple of methods "Get + Ack" while Get return plus the zero events
                transmissionInvoicesNotificationsApi.TransmissionSubscriptionCommit(AooIdentifier, UoIdentifier, transmissionSubscribeResponse.SubscriptionUID, _authToken);
                AddLog("Active cycle - Read without offset - End");

            }
            catch (Exception ex)
            {
                AddLog("Active cycle - Read without offset - Error", ex.ToString());
            }
        }

        private void MenageActiveEvent(IO.Swagger.Model.TransmissionNotification notification)
        {
            var errorMessage = "";
            var sdiIdentifier = "";
            bool fileMustDownload = false;

            switch (notification.NotificationType)
            {
                case "TEMPLATE_ERROR": // this notification arrived when IX FE have an error in the step of generating XML file from PDF file.
                    break;
                case "VALIDATION_ERROR": // the XML file arrived on IX.FE but IX.FE has discarded because not a invalid invoice 
                    if (notification.ValidationError == null)
                        errorMessage = notification.Message;
                    else
                        errorMessage = notification.ValidationError.Note;
                    break;
                case "SDI_DELIVERED": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI (italian agency)
                    DateTime dataOraInvioSdi = notification.UtcDate.Value.ToLocalTime();
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "SIGN_ERROR": // the XML file arrived on IX.FE but in IX.FE system the file encurred in an error in the sign step
                    errorMessage = notification.Message;
                    break;
                case "FAILED_DELIVERY_B2B": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has return an error : Failed Delivery (Notifica di Impossibilità di Recapito)
                    var notDeliveryDateTimeB2B = notification.B2bNotifications.FailedDelivery.NotDeliveryDateTime;
                    if (notification.B2bNotifications.FailedDelivery.ReservedAreaAvailableDateTime != null)
                    {
                        var reservedAreaAvailableDateTimeB2B = notification.B2bNotifications.FailedDelivery.ReservedAreaAvailableDateTime.Value;
                    }
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "FAILED_DELIVERY_PA": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has return an error : Failed Delivery (Notifica di Impossibilità di Recapito)
                    var notDeliveryDateTimePa = notification.PaNotifications.FailedDelivery.NotDeliveryDateTime;
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "DELIVERY_RECEIPT_B2B": //the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has sent the file at the receiver
                    var deliveryDateTimeB2B = notification.B2bNotifications.DeliveryReceipt.DeliveryDateTime;
                    //Dal_ActiveInvoice_SetDeliveryDateTime(transaction, evento.InvoiceUID, evento.B2bNotifications.DeliveryReceipt.DeliveryDateTime);
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "DELIVERY_RECEIPT_PA": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has sent the file at the PA receiver
                    var deliveryDateTimePa = notification.PaNotifications.DeliveryReceipt.DeliveryDateTime;
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "PROOF_OF_TRANSMISSION_PA": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has sent to the sender "attestazione Trasmissione con Impossibilità di Recapito"
                    var proofOfTransmissionDateTime = notification.PaNotifications.ProofOfTransmission.ProofOfTransmissionDateTime;
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "REJECTION_B2B": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has return an error : Failed Delivery (Notifica di Scarto)
                    errorMessage = string.Join(" - ", notification.B2bNotifications.Rejection.Errors.Select(x => string.Format("[{0}] {1}", x.Code, x.Description)).ToList());
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "REJECTION_PA": // the XML file arrived on IX.FE and IX.FE has sent it to the SDI. The SDI has return an error : Failed Delivery (Notifica di Scarto)
                    errorMessage = string.Join(" - ", notification.PaNotifications.Rejection.Errors.Select(x => string.Format("[{0}] {1}", x.Code, x.Description)).ToList());
                    sdiIdentifier = notification.ExchangeSystemUID;
                    fileMustDownload = true;
                    break;
                case "OUTCOME_PA": // The PA receiver has sent to the system a response abaout a invoice file
                    var paMessage = notification.PaNotifications.Outcome.Type;
                    if (notification.PaNotifications.Outcome.Type != "ACCEPTED")
                        errorMessage = notification.PaNotifications.Outcome.Motivation;
                    break;
                case "DEADLINE_PASSED_PA": //The PA receiver has no sent into the intervall time a response abaout a invoice file (Decorrenza termini) 

                    break;
                case "CONSERVATION_SENT": //IX.FE has sent into IX.CE system the invoice file
                    var identificativoDocumento = notification.ConservationSent.IdentificativoDocumento;
                    var identificativoVersamento = notification.ConservationSent.IdentificativoVersamento;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Menage Active Event - Stato = '{0}'", notification.NotificationType));
            }

            if (fileMustDownload)
            {
                IO.Swagger.Api.TransmissionInvoicesDownloadApi transmissionInvoicesDownloadApi = new IO.Swagger.Api.TransmissionInvoicesDownloadApi(_urlWebApiInvoice);
                var apiResponseInvoice = transmissionInvoicesDownloadApi.GetTransmissionInvoiceFileWithHttpInfo(AooIdentifier, UoIdentifier, notification.InvoiceUID, _authToken);
                using (var invoiceStream = ConvertToStreamInfo(apiResponseInvoice))
                {
                    var invoicePath = GetNewFileName(invoiceStream.Filename);
                    SaveStream(invoiceStream.Stream, invoicePath);
                }
            }
        }

        private void MenagePassiveEvent(IO.Swagger.Model.ReceptionNotification notification)
        {
            if (notification.NotificationType == "TAKEN_OVER")
            {
                // the passive invoice has arrived in IX FE system from SDI

                //I connect my client to reception invoices endpoint
                IO.Swagger.Api.ReceptionInvoicesDownloadApi receptionInvoicesDownloadApi = new IO.Swagger.Api.ReceptionInvoicesDownloadApi(_urlWebApiInvoice);

                //I download the json of my pasive file
                var apiResponseInvoice = receptionInvoicesDownloadApi.GetReceptionInvoiceFileWithHttpInfo(AooIdentifier, UoIdentifier, notification.InvoiceUID, _authToken);
                using (var invoiceStream = ConvertToStreamInfo(apiResponseInvoice))
                {
                    //I save the strem on my disk
                    var invoicePath = GetNewFileName(invoiceStream.Filename);
                    SaveStream(invoiceStream.Stream, invoicePath);

                    if (invoicePath.EndsWith(".p7m", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //If the file is a P7M I call IX FE to download the unwrapped file (with extension XML)
                        var apiResponseInvoiceWithoutDigitalSign = receptionInvoicesDownloadApi.GetReceptionInvoiceFileUnwrappedWithHttpInfo(AooIdentifier, UoIdentifier, notification.InvoiceUID, _authToken);
                        using (var invoiceStreamWithoutDigitalSign = ConvertToStreamInfo(apiResponseInvoice))
                        {
                            //I save the strem on my disk
                            var invoicePathWithoutDigitalSign = GetNewFileName(invoiceStreamWithoutDigitalSign.Filename);
                            SaveStream(invoiceStreamWithoutDigitalSign.Stream, invoicePathWithoutDigitalSign);
                        }
                    }
                }

                //I download the PDF rapresetation of the first invoice of the file
                apiResponseInvoice = receptionInvoicesDownloadApi.GetReceptionInvoicePdfWithHttpInfo(AooIdentifier, UoIdentifier, notification.InvoiceUID, 1, _authToken);
                using (var invoiceStream = ConvertToStreamInfo(apiResponseInvoice))
                {
                    var invoicePath = GetNewFileName(invoiceStream.Filename);
                    SaveStream(invoiceStream.Stream, invoicePath);
                }

                //I download the XML metadata file sended at IX FE from SDI
                apiResponseInvoice = receptionInvoicesDownloadApi.GetReceptionInvoiceSdIMetadataWithHttpInfo(AooIdentifier, UoIdentifier, notification.InvoiceUID, _authToken);
                using (var metadataStream = ConvertToStreamInfo(apiResponseInvoice))
                {
                    var metadataPath = GetNewFileName(metadataStream.Filename);
                    SaveStream(metadataStream.Stream, metadataPath);
                }

                if (notification.TakenOver.Profiles != null)
                {
                    var senderPhoneValue = "";
                    var senderMailValue = "";
                    var sequenceValue = "";

                    if (notification.TakenOver.Metadata != null)
                    {
                        var senderPhone = notification.TakenOver.Metadata.FirstOrDefault(x => x.Name == "SENDER_PHONE");
                        if (senderPhone != null)
                            senderPhoneValue = senderPhone.Value;

                        var senderMail = notification.TakenOver.Metadata.FirstOrDefault(x => x.Name == "SENDER_EMAIL");
                        if (senderMail != null)
                            senderMailValue = senderMail.Value;

                        var sequence = notification.TakenOver.Metadata.FirstOrDefault(x => x.Name == "SEQUENCE");
                        if (sequence != null)
                            sequenceValue = sequence.Value;
                    }

                    foreach (var profile in notification.TakenOver.Profiles)
                    {
                        if (profile.Metadata != null)
                        {
                            var invoiceNumberValue = "";
                            var invoiceDataValue = "";
                            var arrivalProtocolValue = "";
                            var documentTypeValue = "";
                            var currencyValue = "";
                            int? indexValue = null;

                            var invoiceNumber = profile.Metadata.FirstOrDefault(x => x.Name == "INVOICE_NUMBER");
                            if (invoiceNumber != null)
                                invoiceNumberValue = invoiceNumber.Value;
                            var invoiceData = profile.Metadata.FirstOrDefault(x => x.Name == "INVOICE_DATE");
                            if (invoiceData != null)
                                invoiceDataValue = invoiceData.Value;
                            var arrivalProtocol = profile.Metadata.FirstOrDefault(x => x.Name == "ARRIVAL_PROTOCOL");
                            if (arrivalProtocol != null)
                                arrivalProtocolValue = arrivalProtocol.Value;
                            var documentType = profile.Metadata.FirstOrDefault(x => x.Name == "DOCUMENT_TYPE");
                            if (documentType != null)
                                documentTypeValue = documentType.Value;
                            var currency = profile.Metadata.FirstOrDefault(x => x.Name == "CURRENCY");
                            if (currency != null)
                                currencyValue = currency.Value;
                            var index = profile.Metadata.FirstOrDefault(x => x.Name == "INDEX");
                            if (index != null)
                                indexValue = Convert.ToInt32(index.Value);
                        }
                    }
                }
            }

            if (notification.NotificationType == "CONSERVATION_SENT")
            {
                // the passive invoice has arrived in IX CE system from IX FE
                var pdvIxceIdentifier = notification.ConservationSent.IdentificativoVersamento;
                var documentIxceIdentifier = notification.ConservationSent.IdentificativoDocumento;
            }
        }

        private StreamInfo ConvertToStreamInfo(IO.Swagger.Client.ApiResponse<Stream> apiResponse)
        {
            var content = apiResponse.Headers["Content-Disposition"];
            var disposition = new System.Net.Mime.ContentDisposition(content);

            var streamResult = new StreamInfo();
            streamResult.Stream = apiResponse.Data;
            streamResult.Filename = disposition.FileName;
            return streamResult;
        }

        protected string GetNewFileName(string fileName)
        {
            var estensione = GetExtension(fileName);
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + estensione);
        }

        protected string GetExtension(string fileName)
        {
            var onlyFileName = Path.GetFileName(fileName);
            if (string.IsNullOrEmpty(onlyFileName))
                return string.Empty;
            var estensione = Regex.Match(onlyFileName, @"\..*").Value;
            return estensione;
        }

        private bool IsBase64Encoded(byte[] signedByteData, out Stream decodedStream)
        {
            decodedStream = null;
            try
            {
                var p7mDecoded = Org.BouncyCastle.Utilities.Encoders.Base64.Decode(signedByteData);
                decodedStream = new MemoryStream(p7mDecoded);
                decodedStream.Seek(0, SeekOrigin.Begin);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ExtractDataFromSigned(Stream signedData, string extractedFileLocation)
        {
            try
            {
                signedData.Seek(0, SeekOrigin.Begin);
                CmsSignedData cms = new CmsSignedData(signedData);
                if (cms.SignedContent != null)
                {
                    if (File.Exists(extractedFileLocation))
                        File.Delete(extractedFileLocation);
                    var fs = new FileStream(extractedFileLocation, FileMode.CreateNew, FileAccess.ReadWrite);
                    cms.SignedContent.Write(fs);
                    fs.Close();
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        private void AddLog(string message)
        {
            AddLog(message, null);
        }

        private void AddLog(string message, string additionalMessage)
        {
            _txtLog.Text += string.Format("{0}{1} - {2} {3}", Environment.NewLine, DateTime.Now, message, additionalMessage);
        }

        private void buttonLoadInvoice_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    textBoxInvoicePath.Text = openFileDialog.FileName;
            }
        }

        private void buttonSendInvoiceToIxFe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(textBoxInvoicePath.Text))
                    throw new FileNotFoundException("Select a file from disk before press the button");

                TxtInvoiceUploadedIdentifier.Text = string.Empty;

                IO.Swagger.Api.TransmissionInvoicesUploadApi transmissionInvoicesUploadApi = new IO.Swagger.Api.TransmissionInvoicesUploadApi(_urlWebApiInvoice);
                var file = new IO.Swagger.Model.TransmissionFile(textBoxInvoicePath.Text, System.IO.File.ReadAllBytes(textBoxInvoicePath.Text));

                var invoice = new IO.Swagger.Model.TransmissionInvoice()
                {
                    Profile = new IO.Swagger.Model.TransmissionProfile()
                    {
                        Metadata = new List<IO.Swagger.Model.TransmissionProfileMetadata>
                        {
                            new IO.Swagger.Model.TransmissionProfileMetadata("SEZIONALE_IVA", "PA")
                        }
                    },
                    Attachments = new List<IO.Swagger.Model.TransmissionFile>(), // this is the attachment list 
                    //ProfileUID = 1 
                };

                var invoiceUploadRequest = new IO.Swagger.Model.TransmissionUploadInvoiceRequest(file, new List<IO.Swagger.Model.TransmissionInvoice> { invoice }, "MioID2"); // NOTA: è un dato univoco a livello di AOO e deve soddisfare la regex: ^[a-zA-Z0-9_]*$

                var uploadInvoiceResponse = transmissionInvoicesUploadApi.TransmissionUploadInvoice(AooIdentifier, UoIdentifier, invoiceUploadRequest, _authToken);

                if (!string.IsNullOrEmpty(uploadInvoiceResponse.InvoiceUID))
                {
                    MessageBox.Show(string.Format("Invoice uploaded correctly on IX FE.{0}Invoice unique code on IX FE: '{1}'", Environment.NewLine, uploadInvoiceResponse.InvoiceUID), "Esito trasmissione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtInvoiceUploadedIdentifier.Text = uploadInvoiceResponse.InvoiceUID;
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AddLog("Active cycle - Read with offset - Start");
                IO.Swagger.Api.TransmissionInvoicesNotificationsApi transmissionInvoicesNotificationsApi = new IO.Swagger.Api.TransmissionInvoicesNotificationsApi(_urlWebApiInvoice);

                DateTime? data = DateTime.Now.AddDays(-80).ToUniversalTime();
                //I create a new subscription. I must send the datetime or the last notification ID  
                var transmissionOffsetSubscribeResponse = transmissionInvoicesNotificationsApi.TransmissionOffsetSubscribe(AooIdentifier, UoIdentifier, new IO.Swagger.Model.TransmissionSubscribeOffsetRequest(null, data), _authToken);

                //I download from IX FE the next list of top 10 events
                var transmissionOffsetNotificationsResponse = transmissionInvoicesNotificationsApi.GetTransmissionOffsetNotifications(AooIdentifier, UoIdentifier, transmissionOffsetSubscribeResponse.SubscriptionUID, 10, _authToken);
                foreach (var notification in transmissionOffsetNotificationsResponse.Notifications)
                {
                    //foreac event I must manage the event's detail
                    MenageActiveEvent(notification);
                }

                //Now I call the Unsubscribe method. If you prefer you can cycle and call next the "get methods" while Get return plus the zero events
                transmissionInvoicesNotificationsApi.TransmissionOffsetUnsubscribe(AooIdentifier, UoIdentifier, transmissionOffsetSubscribeResponse.SubscriptionUID, _authToken);

                AddLog("Active cycle - Read with offset - End");

            }
            catch (Exception ex)
            {
                AddLog("Active cycle - Read with offset - Error", ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddLog("Passive cycle - Read without offset - Start");

            IO.Swagger.Api.ReceptionInvoicesNotificationsApi ReceptionInvoicesNotificationsApi = new IO.Swagger.Api.ReceptionInvoicesNotificationsApi(_urlWebApiInvoice);

            //I create a new subscription without parameters. The IX.FE server know when I have downloaded the notifications in the past
            var receptionSubscribeResponse = ReceptionInvoicesNotificationsApi.ReceptionSubscribe(AooIdentifier, UoIdentifier, _authToken);
            //I download from IX FE the next list of top 10 events
            var receptionNotificationsResponse = ReceptionInvoicesNotificationsApi.GetReceptionNotifications(AooIdentifier, UoIdentifier, receptionSubscribeResponse.SubscriptionUID, 10, _authToken);
            foreach (var notification in receptionNotificationsResponse.Notifications)
            {
                //foreac event I must manage the event's detail
                MenagePassiveEvent(notification);
            }
            //Now I call the ACK to inform the IX FE server that I have readed correctply all the events dopwnloaded
            ReceptionInvoicesNotificationsApi.ReceptionSubscriptionAck(AooIdentifier, UoIdentifier, receptionSubscribeResponse.SubscriptionUID, receptionNotificationsResponse.AckUID, _authToken);
            //Now I call the Commit to close the Subscription
            ReceptionInvoicesNotificationsApi.ReceptionSubscriptionCommit(AooIdentifier, UoIdentifier, receptionSubscribeResponse.SubscriptionUID, _authToken);
            AddLog("Passive cycle - Read without offset - End");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddLog("Passive cycle - Read with offset - Start");
            IO.Swagger.Api.ReceptionInvoicesNotificationsApi ReceptionInvoicesNotificationsApi = new IO.Swagger.Api.ReceptionInvoicesNotificationsApi(_urlWebApiInvoice);

            DateTime? data = DateTime.Now.AddDays(-90).ToUniversalTime();
            var receptionOffsetSubscribeResponse = ReceptionInvoicesNotificationsApi.ReceptionOffsetSubscribe(AooIdentifier, UoIdentifier, new IO.Swagger.Model.ReceptionSubscribeOffsetRequest(null, data), _authToken);
            var receptionOffsetNotificationsResponse = ReceptionInvoicesNotificationsApi.GetReceptionOffsetNotifications(AooIdentifier, UoIdentifier, receptionOffsetSubscribeResponse.SubscriptionUID, 10, _authToken);
            foreach (var notification in receptionOffsetNotificationsResponse.Notifications)
            {
                MenagePassiveEvent(notification);
            }
            ReceptionInvoicesNotificationsApi.ReceptionOffsetUnsubscribe(AooIdentifier, UoIdentifier, receptionOffsetSubscribeResponse.SubscriptionUID, _authToken);
            AddLog("Passive cycle - Read with offset - End");
        }
    }
}