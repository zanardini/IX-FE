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
    /// Represent a validation error code
    /// </summary>
    [DataContract]
    public partial class TransmissionValidationErrorNotificationError :  IEquatable<TransmissionValidationErrorNotificationError>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionValidationErrorNotificationError" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionValidationErrorNotificationError() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionValidationErrorNotificationError" /> class.
        /// </summary>
        /// <param name="code">Error code (required).</param>
        /// <param name="description">Description (required).</param>
        public TransmissionValidationErrorNotificationError(string code = default(string), string description = default(string))
        {
            // to ensure "code" is required (not null)
            if (code == null)
            {
                throw new InvalidDataException("code is a required property for TransmissionValidationErrorNotificationError and cannot be null");
            }
            else
            {
                this.Code = code;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for TransmissionValidationErrorNotificationError and cannot be null");
            }
            else
            {
                this.Description = description;
            }
        }
        
        /// <summary>
        /// Error code
        /// </summary>
        /// <value>Error code</value>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>Description</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionValidationErrorNotificationError {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as TransmissionValidationErrorNotificationError);
        }

        /// <summary>
        /// Returns true if TransmissionValidationErrorNotificationError instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionValidationErrorNotificationError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionValidationErrorNotificationError input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
