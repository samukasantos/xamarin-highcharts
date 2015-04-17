
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.HighCharts.Utils
{
    class CodeValueCollection
    {
        #region Fields

        private List<CodeValue> _codeValueCollection;

        #endregion

        #region Properties

        public List<CodeValue> Items { get { return _codeValueCollection; } }

        public CodeValue this[string value]
        {
            get { return _codeValueCollection.FirstOrDefault(c => c.Value == value); }
        }

        #endregion

        #region Constructor

        public CodeValueCollection()
        {
            _codeValueCollection = new List<CodeValue>();
        }

        #endregion
    }
}
