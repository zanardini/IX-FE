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
    /// Represent the invoice upload entity
    /// </summary>
    [DataContract]
    public partial class TransmissionUploadInvoiceRequest :  IEquatable<TransmissionUploadInvoiceRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionUploadInvoiceRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionUploadInvoiceRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionUploadInvoiceRequest" /> class.
        /// </summary>
        /// <param name="invoiceFile">Invoice file (required).</param>
        /// <param name="profiles">Invoice profiles.</param>
        /// <param name="externalId">External id.</param>
        public TransmissionUploadInvoiceRequest(TransmissionFile invoiceFile = default(TransmissionFile), List<TransmissionInvoice> profiles = default(List<TransmissionInvoice>), string externalId = default(string))
        {
            // to ensure "invoiceFile" is required (not null)
            if (invoiceFile == null)
            {
                throw new InvalidDataException("invoiceFile is a required property for TransmissionUploadInvoiceRequest and cannot be null");
            }
            else
            {
                this.InvoiceFile = invoiceFile;
            }
            this.Profiles = profiles;
            this.ExternalId = externalId;
        }
        
        /// <summary>
        /// Invoice file
        /// </summary>
        /// <value>Invoice file</value>
        [DataMember(Name="invoiceFile", EmitDefaultValue=false)]
        public TransmissionFile InvoiceFile { get; set; }

        /// <summary>
        /// Invoice profiles
        /// </summary>
        /// <value>Invoice profiles</value>
        [DataMember(Name="profiles", EmitDefaultValue=false)]
        public List<TransmissionInvoice> Profiles { get; set; }

        /// <summary>
        /// External id
        /// </summary>
        /// <value>External id</value>
        [DataMember(Name="externalId", EmitDefaultValue=false)]
        public string ExternalId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionUploadInvoiceRequest {\n");
            sb.Append("  InvoiceFile: ").Append(InvoiceFile).Append("\n");
            sb.Append("  Profiles: ").Append(Profiles).Append("\n");
            sb.Append("  ExternalId: ").Append(ExternalId).Append("\n");
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
            return this.Equals(input as TransmissionUploadInvoiceRequest);
        }

        /// <summary>
        /// Returns true if TransmissionUploadInvoiceRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionUploadInvoiceRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionUploadInvoiceRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.InvoiceFile == input.InvoiceFile ||
                    (this.InvoiceFile != null &&
                    this.InvoiceFile.Equals(input.InvoiceFile))
                ) && 
                (
                    this.Profiles == input.Profiles ||
                    this.Profiles != null &&
                    this.Profiles.SequenceEqual(input.Profiles)
                ) && 
                (
                    this.ExternalId == input.ExternalId ||
                    (this.ExternalId != null &&
                    this.ExternalId.Equals(input.ExternalId))
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
                if (this.InvoiceFile != null)
                    hashCode = hashCode * 59 + this.InvoiceFile.GetHashCode();
                if (this.Profiles != null)
                    hashCode = hashCode * 59 + this.Profiles.GetHashCode();
                if (this.ExternalId != null)
                    hashCode = hashCode * 59 + this.ExternalId.GetHashCode();
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