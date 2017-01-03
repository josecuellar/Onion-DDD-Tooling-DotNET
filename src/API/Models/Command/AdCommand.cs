using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Command
{
    public class AdCommand : IAsyncRequest<bool>
    {
        public string Id { get; set; }

        public string Title { get; set; }
    }
}