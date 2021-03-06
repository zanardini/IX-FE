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
    /// PA Notifications
    /// </summary>
    [DataContract]
    public partial class ReceptionPANotification :  IEquatable<ReceptionPANotification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionPANotification" /> class.
        /// </summary>
        /// <param name="outcome">Outcome notification.</param>
        /// <param name="outcomeRejection">Outcome Rejection notification.</param>
        public ReceptionPANotification(ReceptionOutcomePANotification outcome = default(ReceptionOutcomePANotification), ReceptionOutcomeRejectionPANotification outcomeRejection = default(ReceptionOutcomeRejectionPANotification))
        {
            this.Outcome = outcome;
            this.OutcomeRejection = outcomeRejection;
        }
        
        /// <summary>
        /// Outcome notification
        /// </summary>
        /// <value>Outcome notification</value>
        [DataMember(Name="outcome", EmitDefaultValue=false)]
        public ReceptionOutcomePANotification Outcome { get; set; }

        /// <summary>
        /// Outcome Rejection notification
        /// </summary>
        /// <value>Outcome Rejection notification</value>
        [DataMember(Name="outcomeRejection", EmitDefaultValue=false)]
        public ReceptionOutcomeRejectionPANotification OutcomeRejection { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReceptionPANotification {\n");
            sb.Append("  Outcome: ").Append(Outcome).Append("\n");
            sb.Append("  OutcomeRejection: ").Append(OutcomeRejection).Append("\n");
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
            return this.Equals(input as ReceptionPANotification);
        }

        /// <summary>
        /// Returns true if ReceptionPANotification instances are equal
        /// </summary>
        /// <param name="input">Instance of ReceptionPANotification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReceptionPANotification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Outcome == input.Outcome ||
                    (this.Outcome != null &&
                    this.Outcome.Equals(input.Outcome))
                ) && 
                (
                    this.OutcomeRejection == input.OutcomeRejection ||
                    (this.OutcomeRejection != null &&
                    this.OutcomeRejection.Equals(input.OutcomeRejection))
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
                if (this.Outcome != null)
                    hashCode = hashCode * 59 + this.Outcome.GetHashCode();
                if (this.OutcomeRejection != null)
                    hashCode = hashCode * 59 + this.OutcomeRejection.GetHashCode();
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
