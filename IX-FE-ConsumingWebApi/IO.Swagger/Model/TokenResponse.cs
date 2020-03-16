/* 
 * OAuth API V2
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v2
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
    /// TokenResponse
    /// </summary>
    [DataContract]
    public partial class TokenResponse :  IEquatable<TokenResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TokenResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenResponse" /> class.
        /// </summary>
        /// <param name="accessToken">Gets or Sets Access_Token (required).</param>
        /// <param name="tokenType">Gets or Sets Token_Type (required).</param>
        /// <param name="expiresIn">Gets or Sets Expires_In (required).</param>
        /// <param name="refreshToken">Gets or Sets Refresh_Token.</param>
        /// <param name="requiredAction">Gets or Sets Required_Action.</param>
        public TokenResponse(string accessToken = default(string), string tokenType = default(string), int? expiresIn = default(int?), string refreshToken = default(string), string requiredAction = default(string))
        {
            // to ensure "accessToken" is required (not null)
            if (accessToken == null)
            {
                throw new InvalidDataException("accessToken is a required property for TokenResponse and cannot be null");
            }
            else
            {
                this.AccessToken = accessToken;
            }
            // to ensure "tokenType" is required (not null)
            if (tokenType == null)
            {
                throw new InvalidDataException("tokenType is a required property for TokenResponse and cannot be null");
            }
            else
            {
                this.TokenType = tokenType;
            }
            // to ensure "expiresIn" is required (not null)
            if (expiresIn == null)
            {
                throw new InvalidDataException("expiresIn is a required property for TokenResponse and cannot be null");
            }
            else
            {
                this.ExpiresIn = expiresIn;
            }
            this.RefreshToken = refreshToken;
            this.RequiredAction = requiredAction;
        }
        
        /// <summary>
        /// Gets or Sets Access_Token
        /// </summary>
        /// <value>Gets or Sets Access_Token</value>
        [DataMember(Name="access_token", EmitDefaultValue=false)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or Sets Token_Type
        /// </summary>
        /// <value>Gets or Sets Token_Type</value>
        [DataMember(Name="token_type", EmitDefaultValue=false)]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or Sets Expires_In
        /// </summary>
        /// <value>Gets or Sets Expires_In</value>
        [DataMember(Name="expires_in", EmitDefaultValue=false)]
        public int? ExpiresIn { get; set; }

        /// <summary>
        /// Gets or Sets Refresh_Token
        /// </summary>
        /// <value>Gets or Sets Refresh_Token</value>
        [DataMember(Name="refresh_token", EmitDefaultValue=false)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or Sets Required_Action
        /// </summary>
        /// <value>Gets or Sets Required_Action</value>
        [DataMember(Name="required_action", EmitDefaultValue=false)]
        public string RequiredAction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TokenResponse {\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
            sb.Append("  ExpiresIn: ").Append(ExpiresIn).Append("\n");
            sb.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
            sb.Append("  RequiredAction: ").Append(RequiredAction).Append("\n");
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
            return this.Equals(input as TokenResponse);
        }

        /// <summary>
        /// Returns true if TokenResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccessToken == input.AccessToken ||
                    (this.AccessToken != null &&
                    this.AccessToken.Equals(input.AccessToken))
                ) && 
                (
                    this.TokenType == input.TokenType ||
                    (this.TokenType != null &&
                    this.TokenType.Equals(input.TokenType))
                ) && 
                (
                    this.ExpiresIn == input.ExpiresIn ||
                    (this.ExpiresIn != null &&
                    this.ExpiresIn.Equals(input.ExpiresIn))
                ) && 
                (
                    this.RefreshToken == input.RefreshToken ||
                    (this.RefreshToken != null &&
                    this.RefreshToken.Equals(input.RefreshToken))
                ) && 
                (
                    this.RequiredAction == input.RequiredAction ||
                    (this.RequiredAction != null &&
                    this.RequiredAction.Equals(input.RequiredAction))
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
                if (this.AccessToken != null)
                    hashCode = hashCode * 59 + this.AccessToken.GetHashCode();
                if (this.TokenType != null)
                    hashCode = hashCode * 59 + this.TokenType.GetHashCode();
                if (this.ExpiresIn != null)
                    hashCode = hashCode * 59 + this.ExpiresIn.GetHashCode();
                if (this.RefreshToken != null)
                    hashCode = hashCode * 59 + this.RefreshToken.GetHashCode();
                if (this.RequiredAction != null)
                    hashCode = hashCode * 59 + this.RequiredAction.GetHashCode();
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
