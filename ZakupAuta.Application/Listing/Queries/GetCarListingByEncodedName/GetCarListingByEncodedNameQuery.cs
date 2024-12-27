using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakupAuta.Application.Listing.Queries.GetCarListingByEncodedName
{
    public class GetCarListingByEncodedNameQuery : IRequest<ListingDto>
    {
        public string EncodedName { get; set; }

        public GetCarListingByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}