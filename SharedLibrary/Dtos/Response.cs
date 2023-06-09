﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{//apilardaki endpointten response sınıfını döneceğiö
    public class Response<T> where T:class//her bir entity ye istek yapıldığında başarılı da olsa başarısız da olsa tek bir model döneceğiz.
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }//clientlara açmayacağım kendi iç yapımda kullanacağım.
        public ErrorDto Error { get; private set; }
        public static Response<T>Success(T data,int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode,IsSuccessful=true };

        }
        public static Response<T> Fail(ErrorDto errorDto,int statusCode)
        {
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
        public static Response<T> Fail(string errorMessage,int statusCode,bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new Response<T> { Error = errorDto, StatusCode = statusCode,IsSuccessful=false};
        }
    }
}
