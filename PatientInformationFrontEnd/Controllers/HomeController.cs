﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientInformationFrontEnd.Models;
using PatientInformationFrontEnd.Services;
using System.Diagnostics;

namespace PatientInformationFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientInformationService _patientInformationService;

        public HomeController(ILogger<HomeController> logger, IPatientInformationService patientInformationService)
        {
            _logger = logger;
            _patientInformationService = patientInformationService;
        }

        public IActionResult Index()
        {
            try
            {
                var obj = new PatientInformationView();
                //var res = _patientInformationService.getAllPatientDetails().Result.ToList();
                var Diseases = _patientInformationService.getAllDiseases().Result.ToList();
                var allergies= _patientInformationService.getAllAllergies().Result.ToList();
                var ncds = _patientInformationService.getAllNCDs().Result.ToList();

                obj.Allergies = allergies;
                obj.DiseaseInformations = Diseases;
                obj.NCDs = ncds;

                return View(obj);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        [HttpPost]
        public IActionResult Index(PatientInformationView patientInformation)
        {
            try
            {
                var s = _patientInformationService.postPatientInformation(patientInformation);

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}