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
    /// ReceptionInsertNotificationOutcomeRequest
    /// </summary>
    [DataContract]
    public partial class ReceptionInsertNotificationOutcomeRequest :  IEquatable<ReceptionInsertNotificationOutcomeRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionInsertNotificationOutcomeRequest" /> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="profileUIDs">profileUIDs.</param>
        public ReceptionInsertNotificationOutcomeRequest(string description = default(string), List<int?> profileUIDs = default(List<int?>))
        {
            this.Description = description;
            this.ProfileUIDs = profileUIDs;
        }
        
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ProfileUIDs
        /// </summary>
        [DataMember(Name="profileUIDs", EmitDefaultValue=false)]
        public List<int?> ProfileUIDs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReceptionInsertNotificationOutcomeRequest {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ProfileUIDs: ").Append(ProfileUIDs).Append("\n");
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
            return this.Equals(input as ReceptionInsertNotificationOutcomeRequest);
        }

        /// <summary>
        /// Returns true if ReceptionInsertNotificationOutcomeRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ReceptionInsertNotificationOutcomeRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReceptionInsertNotificationOutcomeRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ProfileUIDs == input.ProfileUIDs ||
                    this.ProfileUIDs != null &&
                    this.ProfileUIDs.SequenceEqual(input.ProfileUIDs)
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
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.ProfileUIDs != null)
                    hashCode = hashCode * 59 + this.ProfileUIDs.GetHashCode();
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
