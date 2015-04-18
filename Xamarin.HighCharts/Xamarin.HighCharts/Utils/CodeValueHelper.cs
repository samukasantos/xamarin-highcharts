

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xamarin.HighCharts.Utils
{
    public class CodeValueHelper
    {
        public static ObservableCollection<CodeValue> Collection(IEnumerable<CodeValue> baseCollection)
        {
            var defaultValue = new CodeValue { Code = "0", Value = "Selecione" };
            var items        = new List<CodeValue>();

            items.Add(defaultValue);
            items.AddRange(baseCollection);

            return new ObservableCollection<CodeValue>(items);
        }
    }
}
