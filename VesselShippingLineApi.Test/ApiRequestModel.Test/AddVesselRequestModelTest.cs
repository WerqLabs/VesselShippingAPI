namespace VesselShippingLineApi.Test.ApiReuqestModel.Test
{
    /// <summary>
    /// Test Add Vessel Request Models
    /// </summary>
    public class AddVesselRequestModelTest
    {
        [Fact]
        public void ModelWithEmptyValues()
        {
            AddVesselRequestModel model = new();
            IList<ValidationResult> results = model.Validate();
            Assert.True(results.Count > 0);
        }
        [Fact]
        public void ModelWithInvalidValues()
        {
            AddVesselRequestModel model = new()
            { ShipName = "Test@123"};
            IList<ValidationResult> results = model.Validate();
            Assert.True(results.Count > 0);
        }
    }
}
