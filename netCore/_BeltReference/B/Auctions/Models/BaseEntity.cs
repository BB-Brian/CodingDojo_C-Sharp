using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Auctions.Models;

namespace Auctions
{
    public class BaseEntity
    {
    public DateTime CreatedAt{get;set;} = DateTime.Now;
    public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}