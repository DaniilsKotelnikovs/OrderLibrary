﻿using OrderLibrary.Services.Interfaces;

namespace OrderLibrary.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}