namespace VesselShippingLineApi.Test.ApiReuqestModel.Test
{
    /// <summary>
    /// Test Velocity Request Model
    /// </summary>
    public class VelocityRequestModelTest
    {
        [Fact]
        public void ModelWithEmptyValues()
        {
            VelocityRequestModel model = new();
            IList<ValidationResult> results = model.Validate();
            Assert.True(results.Count > 0);
        }
        [Fact]
        public void ModelWithInvalidValues()
        {
            VelocityRequestModel model = new()
            {
                ShipId = null,
                Velocity = null,
                Latitude = 1339.3434,
                Longitude = 73333.8899
            };
            IList<ValidationResult> results = model.Validate();
            Assert.True(results.Count > 0);
        }
    }
}
