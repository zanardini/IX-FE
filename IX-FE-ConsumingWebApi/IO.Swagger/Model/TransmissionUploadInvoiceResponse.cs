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
    /// Represent the result of invoice upload
    /// </summary>
    [DataContract]
    public partial class TransmissionUploadInvoiceResponse :  IEquatable<TransmissionUploadInvoiceResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionUploadInvoiceResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionUploadInvoiceResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionUploadInvoiceResponse" /> class.
        /// </summary>
        /// <param name="invoiceUID">Invoice unique identifier (required).</param>
        public TransmissionUploadInvoiceResponse(string invoiceUID = default(string))
        {
            // to ensure "invoiceUID" is required (not null)
            if (invoiceUID == null)
            {
                throw new InvalidDataException("invoiceUID is a required property for TransmissionUploadInvoiceResponse and cannot be null");
            }
            else
            {
                this.InvoiceUID = invoiceUID;
            }
        }
        
        /// <summary>
        /// Invoice unique identifier
        /// </summary>
        /// <value>Invoice unique identifier</value>
        [DataMember(Name="invoiceUID", EmitDefaultValue=false)]
        public string InvoiceUID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionUploadInvoiceResponse {\n");
            sb.Append("  InvoiceUID: ").Append(InvoiceUID).Append("\n");
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
            return this.Equals(input as TransmissionUploadInvoiceResponse);
        }

        /// <summary>
        /// Returns true if TransmissionUploadInvoiceResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionUploadInvoiceResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionUploadInvoiceResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.InvoiceUID == input.InvoiceUID ||
                    (this.InvoiceUID != null &&
                    this.InvoiceUID.Equals(input.InvoiceUID))
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
