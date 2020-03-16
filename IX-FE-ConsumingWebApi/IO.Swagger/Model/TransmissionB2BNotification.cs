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
    /// B2B Notifications
    /// </summary>
    [DataContract]
    public partial class TransmissionB2BNotification :  IEquatable<TransmissionB2BNotification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionB2BNotification" /> class.
        /// </summary>
        /// <param name="deliveryReceipt">Delivery receipt notification.</param>
        /// <param name="rejection">Rejection notification.</param>
        /// <param name="failedDelivery">Failed delivery notification.</param>
        public TransmissionB2BNotification(TransmissionDeliveryReceiptB2BNotification deliveryReceipt = default(TransmissionDeliveryReceiptB2BNotification), TransmissionRejectionB2BNotification rejection = default(TransmissionRejectionB2BNotification), TransmissionFailedDeliveryB2BNotification failedDelivery = default(TransmissionFailedDeliveryB2BNotification))
        {
            this.DeliveryReceipt = deliveryReceipt;
            this.Rejection = rejection;
            this.FailedDelivery = failedDelivery;
        }
        
        /// <summary>
        /// Delivery receipt notification
        /// </summary>
        /// <value>Delivery receipt notification</value>
        [DataMember(Name="deliveryReceipt", EmitDefaultValue=false)]
        public TransmissionDeliveryReceiptB2BNotification DeliveryReceipt { get; set; }

        /// <summary>
        /// Rejection notification
        /// </summary>
        /// <value>Rejection notification</value>
        [DataMember(Name="rejection", EmitDefaultValue=false)]
        public TransmissionRejectionB2BNotification Rejection { get; set; }

        /// <summary>
        /// Failed delivery notification
        /// </summary>
        /// <value>Failed delivery notification</value>
        [DataMember(Name="failedDelivery", EmitDefaultValue=false)]
        public TransmissionFailedDeliveryB2BNotification FailedDelivery { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionB2BNotification {\n");
            sb.Append("  DeliveryReceipt: ").Append(DeliveryReceipt).Append("\n");
            sb.Append("  Rejection: ").Append(Rejection).Append("\n");
            sb.Append("  FailedDelivery: ").Append(FailedDelivery).Append("\n");
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
            return this.Equals(input as TransmissionB2BNotification);
        }

        /// <summary>
        /// Returns true if TransmissionB2BNotification instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionB2BNotification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionB2BNotification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DeliveryReceipt == input.DeliveryReceipt ||
                    (this.DeliveryReceipt != null &&
                    this.DeliveryReceipt.Equals(input.DeliveryReceipt))
                ) && 
                (
                    this.Rejection == input.Rejection ||
                    (this.Rejection != null &&
                    this.Rejection.Equals(input.Rejection))
                ) && 
                (
                    this.FailedDelivery == input.FailedDelivery ||
                    (this.FailedDelivery != null &&
                    this.FailedDelivery.Equals(input.FailedDelivery))
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
                if (this.DeliveryReceipt != null)
                    hashCode = hashCode * 59 + this.DeliveryReceipt.GetHashCode();
                if (this.Rejection != null)
                    hashCode = hashCode * 59 + this.Rejection.GetHashCode();
                if (this.FailedDelivery != null)
                    hashCode = hashCode * 59 + this.FailedDelivery.GetHashCode();
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