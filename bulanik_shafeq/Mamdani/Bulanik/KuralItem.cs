using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class KuralItem
    {
        private string _degisken;
        private string _uyelik;

        #region Constructor
        public KuralItem(string Degisken, string Uyelik)
        {
            this._degisken = Degisken;
            this._uyelik = Uyelik;
        }
        #endregion

        #region Getter & Setter
        public string Degisken
        {
            get { return _degisken; }
        }

        public string UyelikDegeri
        {
            get { return _uyelik; }
        }
        #endregion
    }
}
