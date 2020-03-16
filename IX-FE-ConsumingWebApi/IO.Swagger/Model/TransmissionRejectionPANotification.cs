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
    /// Represent a rejection notification for PA
    /// </summary>
    [DataContract]
    public partial class TransmissionRejectionPANotification :  IEquatable<TransmissionRejectionPANotification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionRejectionPANotification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionRejectionPANotification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionRejectionPANotification" /> class.
        /// </summary>
        /// <param name="errors">Errors code (required).</param>
        /// <param name="note">Scarto note.</param>
        public TransmissionRejectionPANotification(List<TransmissionRejectionPANotificationError> errors = default(List<TransmissionRejectionPANotificationError>), string note = default(string))
        {
            // to ensure "errors" is required (not null)
            if (errors == null)
            {
                throw new InvalidDataException("errors is a required property for TransmissionRejectionPANotification and cannot be null");
            }
            else
            {
                this.Errors = errors;
            }
            this.Note = note;
        }
        
        /// <summary>
        /// Errors code
        /// </summary>
        /// <value>Errors code</value>
        [DataMember(Name="errors", EmitDefaultValue=false)]
        public List<TransmissionRejectionPANotificationError> Errors { get; set; }

        /// <summary>
        /// Scarto note
        /// </summary>
        /// <value>Scarto note</value>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionRejectionPANotification {\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
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
            return this.Equals(input as TransmissionRejectionPANotification);
        }

        /// <summary>
        /// Returns true if TransmissionRejectionPANotification instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionRejectionPANotification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionRejectionPANotification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Errors == input.Errors ||
                    this.Errors != null &&
                    this.Errors.SequenceEqual(input.Errors)
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
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
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
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
