﻿using System;

namespace VisaCheckout.VisaHelper.REST
{
    public class ApiKeyManagement : VisaRequestBase, IAdminRestRequest
    {
        public const string ResourceName = "";

        public ApiKeyManagement()
            : base(ResourceName)
        {
        }

        public string Create()
        {
            throw new NotImplementedException();
        }

        public string Delete()
        {
            throw new NotImplementedException();
        }

        public bool SendRequest(string sharedKey, out string responseString)
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            throw new NotImplementedException();
        }
    }
}