using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZakupAuta.Application.Listing;
using ZakupAuta.Application.Listing.Commands.CreateListing;
using ZakupAuta.Application.Listing.Commands.EditCarListing;
using ZakupAuta.Application.Listing.Queries.GetAllCarListings;
using ZakupAuta.Application.Listing.Queries.GetCarListingByEncodedName;
using ZakupAuta.Models;




namespace ZakupAuta.Controllers
{
    public class ListingController : Controller
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;
        public ListingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carListings = await _mediator.Send(new GetAllCarListings());
            return View(carListings);
        }


        [Route("CarListing/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarListingByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CarListing/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarListingByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            EditCarListingCommand model = _mapper.Map<EditCarListingCommand>(dto);

            return View(model);

        }


            [HttpPost]
        [Route("CarListing/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarListingCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarListingCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}