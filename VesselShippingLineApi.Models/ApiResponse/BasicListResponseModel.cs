namespace VesselShippingLineApi.Models.ApiResponse
{
    /// <summary>
    /// Basic List Response Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasicListResponseModel<T>
    {
        public BasicListResponseModel(List<T> records)
        {
            Records = records;
            Count = records.Count;
        }
        public List<T> Records { get; set; }
        public int Count { get; set; }
    }
}
