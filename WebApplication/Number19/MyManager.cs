using Number19.Interface;
using Number19.Model;

namespace Number19
{
    public class MyManager : IMyManager
    {
        public string ProcessData(MyData data)
        {
            // Логика обработки данных
            return $"Processed data: Name={data.Name}, Age={data.Age}";
        }
    }
}
