namespace VesselShippingLineApi.Test.Helper
{
    /// <summary>
    /// Model Validator DAL
    /// </summary>
    public static class ModelValidator
    {
        public static IList<ValidationResult> Validate(this object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
