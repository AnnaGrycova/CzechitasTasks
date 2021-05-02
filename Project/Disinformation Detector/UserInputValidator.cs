﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    public static class UserInputValidator
    {
        public static bool IsDateTime(string publishedOnInput)
        {
            return DateTime.TryParse(publishedOnInput, out _);
        }
        public static bool IsEmptyOrDateTime(string publishedOnInput)
        {
            return (!UserInputValidator.IsNotNullOrEmpty(publishedOnInput) || UserInputValidator.IsDateTime(publishedOnInput));
        }

        public static bool IsUrl(string url)
        {
            //Uri uriResult;
            //bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
            //    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return (!UserInputValidator.IsNotNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute));
        }

        public static bool IsNotNullOrEmpty(string input)
        { 
            return !String.IsNullOrEmpty(input);
        }        
    }
}
