﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTranslater.Domain.Response
{ 
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; }
    }
}
