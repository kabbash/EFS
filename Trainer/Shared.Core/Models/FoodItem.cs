using Shared.Core.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public class FoodItem: IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }
        public decimal Amount { get; set; }
        public decimal Energy { get; set; }
        public decimal Alcohol { get; set; }
        public decimal Caffiene { get; set; }
        public decimal Water { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fiber { get; set; }
        public decimal Starch { get; set; }
        public decimal Sugars { get; set; }
        public decimal NetCarbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Monounsaturated { get; set; }
        public decimal Polyunsaturated { get; set; }
        public decimal Omega3 { get; set; }
        public decimal Omega6 { get; set; }
        public decimal Saturated { get; set; }
        public decimal TransFats { get; set; }
        public decimal Cholesterol { get; set; }
        public decimal Protein { get; set; }
        public decimal Cystine { get; set; }
        public decimal Histidine { get; set; }
        public decimal Isoleucine { get; set; }
        public decimal Leucine { get; set; }
        public decimal Lysine { get; set; }
        public decimal Methionine { get; set; }
        public decimal Phenylalanine { get; set; }
        public decimal Threonine { get; set; }
        public decimal Tryptophan { get; set; }
        public decimal Tyrosine { get; set; }
        public decimal Valine { get; set; }
        public decimal B1 { get; set; }
        public decimal B2 { get; set; }
        public decimal B3 { get; set; }
        public decimal B5 { get; set; }
        public decimal B6 { get; set; }
        public decimal B12 { get; set; }
        public decimal Folate { get; set; }
        public decimal VitaminA { get; set; }
        public decimal VitaminC { get; set; }
        public decimal VitaminD { get; set; }
        public decimal VitaminE { get; set; }
        public decimal VitaminK { get; set; }
        public decimal Calcuim { get; set; }
        public decimal Copper { get; set; }
        public decimal Iron { get; set; }
        public decimal Magnesium { get; set; }
        public decimal Manganese { get; set; }
        public decimal Phosphorus { get; set; }
        public decimal Potassium { get; set; }
        public decimal Selenium { get; set; }
        public decimal Sodium { get; set; }
        public decimal Zinc { get; set; }
        public decimal alanine { get; set; }
        public decimal argnine { get; set; }
        public decimal asparticAcid { get; set; }
        public decimal glotamicAcid { get; set; }
        public decimal glycine { get; set; }
        public decimal hydroxiplorien { get; set; }
        public decimal proline { get; set; }
        public decimal serine { get; set; }
        public decimal chromuim { get; set; }
        public decimal florid { get; set; }
        public decimal yod { get; set; }
        public decimal moly { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDraft { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual AspNetUsers Author { get; set; }
    }
}
