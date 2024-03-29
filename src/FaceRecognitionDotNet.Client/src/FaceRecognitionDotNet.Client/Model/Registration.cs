/*
 * FaceRecognitionDotNet Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FaceRecognitionDotNet.Client.Client.OpenAPIDateConverter;

namespace FaceRecognitionDotNet.Client.Model
{
    /// <summary>
    /// Represents a registration data.
    /// </summary>
    [DataContract(Name = "Registration")]
    public partial class Registration : IEquatable<Registration>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Registration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Registration() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Registration" /> class.
        /// </summary>
        /// <param name="demographics">demographics (required).</param>
        /// <param name="encoding">encoding (required).</param>
        /// <param name="photo">photo (required).</param>
        public Registration(Demographics demographics = default(Demographics), Encoding encoding = default(Encoding), Image photo = default(Image))
        {
            // to ensure "demographics" is required (not null)
            this.Demographics = demographics ?? throw new ArgumentNullException("demographics is a required property for Registration and cannot be null");
            // to ensure "encoding" is required (not null)
            this.Encoding = encoding ?? throw new ArgumentNullException("encoding is a required property for Registration and cannot be null");
            // to ensure "photo" is required (not null)
            this.Photo = photo ?? throw new ArgumentNullException("photo is a required property for Registration and cannot be null");
        }

        /// <summary>
        /// Gets or Sets Demographics
        /// </summary>
        [DataMember(Name = "demographics", IsRequired = true, EmitDefaultValue = false)]
        public Demographics Demographics { get; set; }

        /// <summary>
        /// Gets or Sets Encoding
        /// </summary>
        [DataMember(Name = "encoding", IsRequired = true, EmitDefaultValue = false)]
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Gets or Sets Photo
        /// </summary>
        [DataMember(Name = "photo", IsRequired = true, EmitDefaultValue = false)]
        public Image Photo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Registration {\n");
            sb.Append("  Demographics: ").Append(Demographics).Append("\n");
            sb.Append("  Encoding: ").Append(Encoding).Append("\n");
            sb.Append("  Photo: ").Append(Photo).Append("\n");
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
            return this.Equals(input as Registration);
        }

        /// <summary>
        /// Returns true if Registration instances are equal
        /// </summary>
        /// <param name="input">Instance of Registration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Registration input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Demographics == input.Demographics ||
                    (this.Demographics != null &&
                    this.Demographics.Equals(input.Demographics))
                ) && 
                (
                    this.Encoding == input.Encoding ||
                    (this.Encoding != null &&
                    this.Encoding.Equals(input.Encoding))
                ) && 
                (
                    this.Photo == input.Photo ||
                    (this.Photo != null &&
                    this.Photo.Equals(input.Photo))
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
                if (this.Demographics != null)
                    hashCode = hashCode * 59 + this.Demographics.GetHashCode();
                if (this.Encoding != null)
                    hashCode = hashCode * 59 + this.Encoding.GetHashCode();
                if (this.Photo != null)
                    hashCode = hashCode * 59 + this.Photo.GetHashCode();
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
