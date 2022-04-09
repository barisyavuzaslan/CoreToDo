using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Geriye üretmiş ve upload etmil olduğu pdf dosyasını döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string TransferPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Geriye excel verisini byte dizisi olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] TransferExcel<T>(List<T> list) where T : class, new();

    }
}
