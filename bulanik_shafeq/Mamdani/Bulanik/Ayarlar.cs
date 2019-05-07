using System;
using System.Collections.Generic;
using System.Text;

namespace Mamdani.Bulanik
{
    public class Ayarlar
    {
        private IslMetodu _islem;
        private BaglantiMetodu _andLojigi;

        #region Constructor
        public Ayarlar(IslMetodu Islem, BaglantiMetodu And)
        {
            _islem = Islem;
            _andLojigi = And;
        }
        #endregion

        #region Getter & setter
        public IslMetodu Islem
        {
            get { return _islem; }
            set { _islem = value; }
        }

        public BaglantiMetodu Lojik
        {
            get { return _andLojigi; }
            set { _andLojigi = value; }
        }

        #endregion

    }

   public enum IslMetodu
    {
        Min = 0,
        Carpim = 1
    };

    public enum BaglantiMetodu
    {
        Min = 0,
        Carpim = 1
    };

}
