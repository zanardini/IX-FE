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
    /// Represent an invoice notification collection response message.
    /// </summary>
    [DataContract]
    public partial class TransmissionNotificationsResponse :  IEquatable<TransmissionNotificationsResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionNotificationsResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionNotificationsResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionNotificationsResponse" /> class.
        /// </summary>
        /// <param name="notifications">The notification collection. (required).</param>
        /// <param name="ackUID">A unique identifier representing the acknowledge. (required).</param>
        public TransmissionNotificationsResponse(List<TransmissionNotification> notifications = default(List<TransmissionNotification>), string ackUID = default(string))
        {
            // to ensure "notifications" is required (not null)
            if (notifications == null)
            {
                throw new InvalidDataException("notifications is a required property for TransmissionNotificationsResponse and cannot be null");
            }
            else
            {
                this.Notifications = notifications;
            }
            // to ensure "ackUID" is required (not null)
            if (ackUID == null)
            {
                throw new InvalidDataException("ackUID is a required property for TransmissionNotificationsResponse and cannot be null");
            }
            else
            {
                this.AckUID = ackUID;
            }
        }
        
        /// <summary>
        /// The notification collection.
        /// </summary>
        /// <value>The notification collection.</value>
        [DataMember(Name="notifications", EmitDefaultValue=false)]
        public List<TransmissionNotification> Notifications { get; set; }

        /// <summary>
        /// A unique identifier representing the acknowledge.
        /// </summary>
        /// <value>A unique identifier representing the acknowledge.</value>
        [DataMember(Name="ackUID", EmitDefaultValue=false)]
        public string AckUID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionNotificationsResponse {\n");
            sb.Append("  Notifications: ").Append(Notifications).Append("\n");
            sb.Append("  AckUID: ").Append(AckUID).Append("\n");
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
            return this.Equals(input as TransmissionNotificationsResponse);
        }

        /// <summary>
        /// Returns true if TransmissionNotificationsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionNotificationsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionNotificationsResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Notifications == input.Notifications ||
                    this.Notifications != null &&
                    this.Notifications.SequenceEqual(input.Notifications)
                ) && 
                (
                    this.AckUID == input.AckUID ||
                    (this.AckUID != null &&
                    this.AckUID.Equals(input.AckUID))
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
                if (this.Notifications != null)
                    hashCode = hashCode * 59 + this.Notifications.GetHashCode();
                if (this.AckUID != null)
                    hashCode = hashCode * 59 + this.AckUID.GetHashCode();
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
