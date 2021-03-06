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
    /// Represent the invoice profiles for the upload
    /// </summary>
    [DataContract]
    public partial class TransmissionInvoice :  IEquatable<TransmissionInvoice>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionInvoice" /> class.
        /// </summary>
        /// <param name="profileUID">Profile unique identifier.</param>
        /// <param name="profile">Profile.</param>
        /// <param name="attachments">Attachments.</param>
        public TransmissionInvoice(int? profileUID = default(int?), TransmissionProfile profile = default(TransmissionProfile), List<TransmissionFile> attachments = default(List<TransmissionFile>))
        {
            this.ProfileUID = profileUID;
            this.Profile = profile;
            this.Attachments = attachments;
        }
        
        /// <summary>
        /// Profile unique identifier
        /// </summary>
        /// <value>Profile unique identifier</value>
        [DataMember(Name="profileUID", EmitDefaultValue=false)]
        public int? ProfileUID { get; set; }

        /// <summary>
        /// Profile
        /// </summary>
        /// <value>Profile</value>
        [DataMember(Name="profile", EmitDefaultValue=false)]
        public TransmissionProfile Profile { get; set; }

        /// <summary>
        /// Attachments
        /// </summary>
        /// <value>Attachments</value>
        [DataMember(Name="attachments", EmitDefaultValue=false)]
        public List<TransmissionFile> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransmissionInvoice {\n");
            sb.Append("  ProfileUID: ").Append(ProfileUID).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
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
            return this.Equals(input as TransmissionInvoice);
        }

        /// <summary>
        /// Returns true if TransmissionInvoice instances are equal
        /// </summary>
        /// <param name="input">Instance of TransmissionInvoice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransmissionInvoice input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ProfileUID == input.ProfileUID ||
                    (this.ProfileUID != null &&
                    this.ProfileUID.Equals(input.ProfileUID))
                ) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && 
                (
                    this.Attachments == input.Attachments ||
                    this.Attachments != null &&
                    this.Attachments.SequenceEqual(input.Attachments)
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
                if (this.ProfileUID != null)
                    hashCode = hashCode * 59 + this.ProfileUID.GetHashCode();
                if (this.Profile != null)
                    hashCode = hashCode * 59 + this.Profile.GetHashCode();
                if (this.Attachments != null)
                    hashCode = hashCode * 59 + this.Attachments.GetHashCode();
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
