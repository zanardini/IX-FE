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
    /// RestHttpResponseError
    /// </summary>
    [DataContract]
    public partial class RestHttpResponseError :  IEquatable<RestHttpResponseError>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestHttpResponseError" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RestHttpResponseError() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RestHttpResponseError" /> class.
        /// </summary>
        /// <param name="code">code (required).</param>
        /// <param name="reason">reason (required).</param>
        /// <param name="message">message (required).</param>
        public RestHttpResponseError(string code = default(string), string reason = default(string), string message = default(string))
        {
            // to ensure "code" is required (not null)
            if (code == null)
            {
                throw new InvalidDataException("code is a required property for RestHttpResponseError and cannot be null");
            }
            else
            {
                this.Code = code;
            }
            // to ensure "reason" is required (not null)
            if (reason == null)
            {
                throw new InvalidDataException("reason is a required property for RestHttpResponseError and cannot be null");
            }
            else
            {
                this.Reason = reason;
            }
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new InvalidDataException("message is a required property for RestHttpResponseError and cannot be null");
            }
            else
            {
                this.Message = message;
            }
        }
        
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets Reason
        /// </summary>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RestHttpResponseError {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
            return this.Equals(input as RestHttpResponseError);
        }

        /// <summary>
        /// Returns true if RestHttpResponseError instances are equal
        /// </summary>
        /// <param name="input">Instance of RestHttpResponseError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RestHttpResponseError input)
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
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
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
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
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