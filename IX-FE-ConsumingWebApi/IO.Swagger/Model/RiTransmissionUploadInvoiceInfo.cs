/* 
 * IX.FE API V3.1
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v3.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Support information about an upload request
    /// </summary>
    [DataContract]
    public partial class RiTransmissionUploadInvoiceInfo :  IEquatable<RiTransmissionUploadInvoiceInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RiTransmissionUploadInvoiceInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RiTransmissionUploadInvoiceInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RiTransmissionUploadInvoiceInfo" /> class.
        /// </summary>
        /// <param name="invoiceUID">Invoice unique identifier (required).</param>
        /// <param name="externalID">External id.</param>
        /// <param name="uploadUtcDate">The upload date in Utc (required).</param>
        /// <param name="fileName">File name (required).</param>
        /// <param name="uploadUserName">The user who uploaded the document (required).</param>
        public RiTransmissionUploadInvoiceInfo(string invoiceUID = default(string), string externalID = default(string), DateTime? uploadUtcDate = default(DateTime?), string fileName = default(string), string uploadUserName = default(string))
        {
            // to ensure "invoiceUID" is required (not null)
            if (invoiceUID == null)
            {
                throw new InvalidDataException("invoiceUID is a required property for RiTransmissionUploadInvoiceInfo and cannot be null");
            }
            else
            {
                this.InvoiceUID = invoiceUID;
            }
            // to ensure "uploadUtcDate" is required (not null)
            if (uploadUtcDate == null)
            {
                throw new InvalidDataException("uploadUtcDate is a required property for RiTransmissionUploadInvoiceInfo and cannot be null");
            }
            else
            {
                this.UploadUtcDate = uploadUtcDate;
            }
            // to ensure "fileName" is required (not null)
            if (fileName == null)
            {
                throw new InvalidDataException("fileName is a required property for RiTransmissionUploadInvoiceInfo and cannot be null");
            }
            else
            {
                this.FileName = fileName;
            }
            // to ensure "uploadUserName" is required (not null)
            if (uploadUserName == null)
            {
                throw new InvalidDataException("uploadUserName is a required property for RiTransmissionUploadInvoiceInfo and cannot be null");
            }
            else
            {
                this.UploadUserName = uploadUserName;
            }
            this.ExternalID = externalID;
        }
        
        /// <summary>
        /// Invoice unique identifier
        /// </summary>
        /// <value>Invoice unique identifier</value>
        [DataMember(Name="invoiceUID", EmitDefaultValue=false)]
        public string InvoiceUID { get; set; }

        /// <summary>
        /// External id
        /// </summary>
        /// <value>External id</value>
        [DataMember(Name="externalID", EmitDefaultValue=false)]
        public string ExternalID { get; set; }

        /// <summary>
        /// The upload date in Utc
        /// </summary>
        /// <value>The upload date in Utc</value>
        [DataMember(Name="uploadUtcDate", EmitDefaultValue=false)]
        public DateTime? UploadUtcDate { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        /// <value>File name</value>
        [DataMember(Name="fileName", EmitDefaultValue=false)]
        public string FileName { get; set; }

        /// <summary>
        /// The user who uploaded the document
        /// </summary>
        /// <value>The user who uploaded the document</value>
        [DataMember(Name="uploadUserName", EmitDefaultValue=false)]
        public string UploadUserName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RiTransmissionUploadInvoiceInfo {\n");
            sb.Append("  InvoiceUID: ").Append(InvoiceUID).Append("\n");
            sb.Append("  ExternalID: ").Append(ExternalID).Append("\n");
            sb.Append("  UploadUtcDate: ").Append(UploadUtcDate).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  UploadUserName: ").Append(UploadUserName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RiTransmissionUploadInvoiceInfo);
        }

        /// <summary>
        /// Returns true if RiTransmissionUploadInvoiceInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of RiTransmissionUploadInvoiceInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RiTransmissionUploadInvoiceInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.InvoiceUID == input.InvoiceUID ||
                    (this.InvoiceUID != null &&
                    this.InvoiceUID.Equals(input.InvoiceUID))
                ) && 
                (
                    this.ExternalID == input.ExternalID ||
                    (this.ExternalID != null &&
                    this.ExternalID.Equals(input.ExternalID))
                ) && 
                (
                    this.UploadUtcDate == input.UploadUtcDate ||
                    (this.UploadUtcDate != null &&
                    this.UploadUtcDate.Equals(input.UploadUtcDate))
                ) && 
                (
                    this.FileName == input.FileName ||
                    (this.FileName != null &&
                    this.FileName.Equals(input.FileName))
                ) && 
                (
                    this.UploadUserName == input.UploadUserName ||
                    (this.UploadUserName != null &&
                    this.UploadUserName.Equals(input.UploadUserName))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.InvoiceUID != null)
                    hashCode = hashCode * 59 + this.InvoiceUID.GetHashCode();
                if (this.ExternalID != null)
                    hashCode = hashCode * 59 + this.ExternalID.GetHashCode();
                if (this.UploadUtcDate != null)
                    hashCode = hashCode * 59 + this.UploadUtcDate.GetHashCode();
                if (this.FileName != null)
                    hashCode = hashCode * 59 + this.FileName.GetHashCode();
                if (this.UploadUserName != null)
                    hashCode = hashCode * 59 + this.UploadUserName.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
