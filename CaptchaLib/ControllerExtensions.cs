﻿/*
ASP.NET MVC Web Application Captcha Library Copyright (C) 2009-2012 Leonid Gordo

This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; 
either version 3.0 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License along with this library; 
if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
*/

using System.Web.Mvc;

namespace CaptchaLib
{
    public static class ControllerExtensions
    {
        public static CaptchaResult Captcha(this Controller controller)
        {
            return Captcha(controller, new CaptchaImage());
        }

        public static CaptchaResult Captcha(this Controller controller, ICaptchaImage captchaImage, int quality = 50, int width = 150, int height = 45 )
        {
            var captchaValue = captchaImage as ICaptchaValue;
            if (captchaValue != null)
                controller.Session[CaptchaConstants.CaptchaUniqueIdPrefix + captchaImage.CaptchaUniqueId] = captchaValue.RenderedValue;
            return new CaptchaResult(captchaImage, quality, width, height);
        }
    }
}
