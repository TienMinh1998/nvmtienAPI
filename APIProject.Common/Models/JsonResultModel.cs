using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Models
{
  public class JsonResultModel
    {
        public int Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public static JsonResultModel Response(int status, object data, string message)
        {
            JsonResultModel res = new JsonResultModel();
            res.Status = status;
            res.Data = data;
            res.Message = message;
            return res;
        }

        public static JsonResultModel SUCCESS(object data)
        {
            JsonResultModel res = new JsonResultModel();
            res.Status = 200;
            res.Data = data;
            res.Message = "SUCCESS";
            return res;
        }

        public static JsonResultModel ERROR()
        {
            JsonResultModel res = new JsonResultModel();
            res.Status = 404;
            res.Data = "";
            res.Message = "ERROR";
            return res;
        }
    }

}
