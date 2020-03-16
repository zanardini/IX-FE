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
    /// Represent a delivery receipt notification for PA
    /// </summary>
    [DataContract]
    public partial class TransmissionDeliveryReceiptPANotification :  IEquatable<TransmissionDeliveryReceiptPANotification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionDeliveryReceiptPANotification" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransmissionDeliveryReceiptPANotification() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionDeliveryReceiptPANotification" /> class.
        /// </summary>
        /// <param name="deliveryDateTime">Delivery date time (required).</param>
        public TransmissionDeliveryReceiptPANotification(DateTime? deliveryDateTime = default(DateTime?))
        {
            // to ensure "deliveryDateTime" is required (not null)
            if (deliveryDateTime == null)
            {
                throw new InvalidDataException("deliveryDateTime is a required property for TransmissionDeliveryReceiptPANotification and cannot be null");
            }
            else
            {
                this.DeliveryDateTime = deliveryDateTime;
            }
        }
        
        /// <summary>
        /// Delivery date time
        /// </summary>
        /// <value>Delivery date time</value>
        [DataMember(Name="deliveryDateTime", EmitDefaultValue=false)]
        public DateTime? DeliveryDateTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionDeliveryReceiptPANotification {\n");
            sb.Append("  DeliveryDateTime: ").Append(DeliveryDateTime).Append("\n");
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
            return this.Equals(input as TransmissionDeliveryReceiptPANotification);
        }

        /// <summary>
        /// Returns true if TransmissionDeliveryReceiptPANotification instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionDeliveryReceiptPANotification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionDeliveryReceiptPANotification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DeliveryDateTime == input.DeliveryDateTime ||
                    (this.DeliveryDateTime != null &&
                    this.DeliveryDateTime.Equals(input.DeliveryDateTime))
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
                if (this.DeliveryDateTime != null)
                    hashCode = hashCode * 59 + this.DeliveryDateTime.GetHashCode();
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
