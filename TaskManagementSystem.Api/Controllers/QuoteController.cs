using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Api.Exceptions;
using TaskManagementSystem.Api.Resources;
using TaskManagementSystem.Api.Validators;
using TaskManagementSystem.Core.Models;
using TaskManagementSystem.Core.Services;

namespace TaskManagementSystem.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public QuoteController(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService ?? throw new ArgumentNullException(nameof(quoteService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteResource>>> GetQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            var quoteResources = _mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteResource>>(quotes);

            return Ok(quoteResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteResource>> GetQuote(int id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null)
            {
                throw new NotFoundException("Quote not found");
            }

            var quoteResource = _mapper.Map<Quote, QuoteResource>(quote);

            return Ok(quoteResource);
        }

        [HttpPost]
        public async Task<ActionResult<QuoteResource>> CreateQuote([FromBody] SaveQuoteResource saveQuoteResource)
        {
            var validator = new SaveQuoteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveQuoteResource);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var quoteToCreate = _mapper.Map<SaveQuoteResource, Quote>(saveQuoteResource);

            var newQuote = await _quoteService.AddQuoteAsync(quoteToCreate);

            var quote = await _quoteService.GetQuoteByIdAsync(newQuote.QuoteID);

            var quoteResource = _mapper.Map<Quote, QuoteResource>(quote);

            return CreatedAtAction(nameof(GetQuote), new { id = quote.QuoteID }, quoteResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] SaveQuoteResource saveQuoteResource)
        {
            var validator = new SaveQuoteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveQuoteResource);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var quoteToBeUpdated = await _quoteService.GetQuoteByIdAsync(id);

            if (quoteToBeUpdated == null)
            {
                throw new NotFoundException("Quote not found");
            }

            var quote = _mapper.Map<SaveQuoteResource, Quote>(saveQuoteResource);

            await _quoteService.UpdateQuoteAsync(id, quote);
            
            // Retrieve the updated quote after the update.
            var updatedQuote = await _quoteService.GetQuoteByIdAsync(id);
            
            // Map the updated quote to a QuoteResource.
            var updatedQuoteResource = _mapper.Map<Quote, QuoteResource>(updatedQuote);

            return Ok(updatedQuoteResource);    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);

            if (quote == null)
            {
                throw new NotFoundException("Quote not found");
            }

            await _quoteService.DeleteQuoteAsync(id);

            return NoContent();
        }
    }