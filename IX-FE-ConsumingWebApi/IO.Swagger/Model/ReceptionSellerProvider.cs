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
    /// Represent the Seller Provider (Cedente Prestatore)  http://www.fatturapa.gov.it/export/fatturazione/sdi/Specifiche_tecniche_del_formato_FatturaPA_v1.1_EN.pdf
    /// </summary>
    [DataContract]
    public partial class ReceptionSellerProvider :  IEquatable<ReceptionSellerProvider>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionSellerProvider" /> class.
        /// </summary>
        /// <param name="vatNumber">VAT number: country code + tax number.</param>
        /// <param name="fiscalCode">Fiscal code.</param>
        /// <param name="companyName">CompanyName (Denominazione)  Firm, trading name or company name of the seller/provider of  the goods/service to be entered in the case of a non-natural person; entering  this field is an alternative to that of the Nome and Cognome fields below..</param>
        /// <param name="name">name.</param>
        /// <param name="surname">surname.</param>
        public ReceptionSellerProvider(string vatNumber = default(string), string fiscalCode = default(string), string companyName = default(string), string name = default(string), string surname = default(string))
        {
            this.VatNumber = vatNumber;
            this.FiscalCode = fiscalCode;
            this.CompanyName = companyName;
            this.Name = name;
            this.Surname = surname;
        }
        
        /// <summary>
        /// VAT number: country code + tax number
        /// </summary>
        /// <value>VAT number: country code + tax number</value>
        [DataMember(Name="vatNumber", EmitDefaultValue=false)]
        public string VatNumber { get; set; }

        /// <summary>
        /// Fiscal code
        /// </summary>
        /// <value>Fiscal code</value>
        [DataMember(Name="fiscalCode", EmitDefaultValue=false)]
        public string FiscalCode { get; set; }

        /// <summary>
        /// CompanyName (Denominazione)  Firm, trading name or company name of the seller/provider of  the goods/service to be entered in the case of a non-natural person; entering  this field is an alternative to that of the Nome and Cognome fields below.
        /// </summary>
        /// <value>CompanyName (Denominazione)  Firm, trading name or company name of the seller/provider of  the goods/service to be entered in the case of a non-natural person; entering  this field is an alternative to that of the Nome and Cognome fields below.</value>
        [DataMember(Name="companyName", EmitDefaultValue=false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [DataMember(Name="surname", EmitDefaultValue=false)]
        public string Surname { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReceptionSellerProvider {\n");
            sb.Append("  VatNumber: ").Append(VatNumber).Append("\n");
            sb.Append("  FiscalCode: ").Append(FiscalCode).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
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
            return this.Equals(input as ReceptionSellerProvider);
        }

        /// <summary>
        /// Returns true if ReceptionSellerProvider instances are equal
        /// </summary>
        /// <param name="input">Instance of ReceptionSellerProvider to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReceptionSellerProvider input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.VatNumber == input.VatNumber ||
                    (this.VatNumber != null &&
                    this.VatNumber.Equals(input.VatNumber))
                ) && 
                (
                    this.FiscalCode == input.FiscalCode ||
                    (this.FiscalCode != null &&
                    this.FiscalCode.Equals(input.FiscalCode))
                ) && 
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Surname == input.Surname ||
                    (this.Surname != null &&
                    this.Surname.Equals(input.Surname))
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
                if (this.VatNumber != null)
                    hashCode = hashCode * 59 + this.VatNumber.GetHashCode();
                if (this.FiscalCode != null)
                    hashCode = hashCode * 59 + this.FiscalCode.GetHashCode();
                if (this.CompanyName != null)
                    hashCode = hashCode * 59 + this.CompanyName.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Surname != null)
                    hashCode = hashCode * 59 + this.Surname.GetHashCode();
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