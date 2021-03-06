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
    /// Represent a failed delivery notification for B2B
    /// </summary>
    [DataContract]
    public partial class TransmissionFailedDeliveryB2BNotification :  IEquatable<TransmissionFailedDeliveryB2BNotification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionFailedDeliveryB2BNotification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionFailedDeliveryB2BNotification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionFailedDeliveryB2BNotification" /> class.
        /// </summary>
        /// <param name="notDeliveryDateTime">Not delivery date time (required).</param>
        /// <param name="reservedAreaAvailableDateTime">Date by which the file is made available in the reserved area (required).</param>
        public TransmissionFailedDeliveryB2BNotification(DateTime? notDeliveryDateTime = default(DateTime?), DateTime? reservedAreaAvailableDateTime = default(DateTime?))
        {
            // to ensure "notDeliveryDateTime" is required (not null)
            if (notDeliveryDateTime == null)
            {
                throw new InvalidDataException("notDeliveryDateTime is a required property for TransmissionFailedDeliveryB2BNotification and cannot be null");
            }
            else
            {
                this.NotDeliveryDateTime = notDeliveryDateTime;
            }
            // to ensure "reservedAreaAvailableDateTime" is required (not null)
            if (reservedAreaAvailableDateTime == null)
            {
                throw new InvalidDataException("reservedAreaAvailableDateTime is a required property for TransmissionFailedDeliveryB2BNotification and cannot be null");
            }
            else
            {
                this.ReservedAreaAvailableDateTime = reservedAreaAvailableDateTime;
            }
        }
        
        /// <summary>
        /// Not delivery date time
        /// </summary>
        /// <value>Not delivery date time</value>
        [DataMember(Name="notDeliveryDateTime", EmitDefaultValue=false)]
        public DateTime? NotDeliveryDateTime { get; set; }

        /// <summary>
        /// Date by which the file is made available in the reserved area
        /// </summary>
        /// <value>Date by which the file is made available in the reserved area</value>
        [DataMember(Name="reservedAreaAvailableDateTime", EmitDefaultValue=false)]
        public DateTime? ReservedAreaAvailableDateTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionFailedDeliveryB2BNotification {\n");
            sb.Append("  NotDeliveryDateTime: ").Append(NotDeliveryDateTime).Append("\n");
            sb.Append("  ReservedAreaAvailableDateTime: ").Append(ReservedAreaAvailableDateTime).Append("\n");
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
            return this.Equals(input as TransmissionFailedDeliveryB2BNotification);
        }

        /// <summary>
        /// Returns true if TransmissionFailedDeliveryB2BNotification instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionFailedDeliveryB2BNotification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionFailedDeliveryB2BNotification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NotDeliveryDateTime == input.NotDeliveryDateTime ||
                    (this.NotDeliveryDateTime != null &&
                    this.NotDeliveryDateTime.Equals(input.NotDeliveryDateTime))
                ) && 
                (
                    this.ReservedAreaAvailableDateTime == input.ReservedAreaAvailableDateTime ||
                    (this.ReservedAreaAvailableDateTime != null &&
                    this.ReservedAreaAvailableDateTime.Equals(input.ReservedAreaAvailableDateTime))
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
                if (this.NotDeliveryDateTime != null)
                    hashCode = hashCode * 59 + this.NotDeliveryDateTime.GetHashCode();
                if (this.ReservedAreaAvailableDateTime != null)
                    hashCode = hashCode * 59 + this.ReservedAreaAvailableDateTime.GetHashCode();
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
