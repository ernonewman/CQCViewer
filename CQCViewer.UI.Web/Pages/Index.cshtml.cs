using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQCViewer.Shared.Interfaces.Services;
using CQCViewer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CQCViewer.UI.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProvidersSummaryServices _providerSummaryServices;


        public IndexModel(ILogger<IndexModel> logger, IProvidersSummaryServices providerSummaryServices)
        {
            _logger = logger;
            _providerSummaryServices = providerSummaryServices;
        }

        [BindProperty]
        public ProvidersSummary ProvidersSummary { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProvidersSummary = await _providerSummaryServices.GetProviderSummary(string.Empty);

            return Page();
        }
    }
}
