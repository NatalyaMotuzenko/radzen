﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using client.Shared;
using Radzen;
using Radzen.Blazor;
using NorthwindBlazor.Models.Northwind;

namespace NorthwindBlazor.App.Pages
{
    public partial class AddEmployeeModel : BlazorComponent
    {
        [Inject]
        NorthwindService Northwind { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        protected RadzenContent content1;

        protected RadzenHeading pageTitle;

        protected RadzenTemplateForm<Employee> form0;

        protected RadzenLabel label1;

        protected RadzenTextBox lastName;

        protected RadzenRequiredValidator lastNameRequiredValidator;

        protected RadzenLabel label2;

        protected RadzenTextBox firstName;

        protected RadzenRequiredValidator firstNameRequiredValidator;

        protected RadzenLabel label3;

        protected RadzenTextBox title;

        protected RadzenLabel label4;

        protected RadzenTextBox titleOfCourtesy;

        protected RadzenLabel label5;

        protected RadzenDatePicker birthDate;

        protected RadzenLabel label6;

        protected RadzenDatePicker hireDate;

        protected RadzenLabel label7;

        protected RadzenTextBox address;

        protected RadzenLabel label8;

        protected RadzenTextBox city;

        protected RadzenLabel label9;

        protected RadzenTextBox region;

        protected RadzenLabel label10;

        protected RadzenTextBox postalCode;

        protected RadzenLabel label11;

        protected RadzenTextBox country;

        protected RadzenLabel label12;

        protected RadzenTextBox homePhone;

        protected RadzenLabel label13;

        protected RadzenTextBox extension;

        protected RadzenLabel label14;

        protected RadzenTextBox photo;

        protected RadzenLabel label15;

        protected RadzenTextBox notes;

        protected RadzenLabel label16;

        protected RadzenDropDown reportsTo;

        protected RadzenLabel label17;

        protected RadzenTextBox photoPath;

        protected RadzenButton button1;

        protected RadzenButton button2;

        IEnumerable<Employee> _getEmployeesResult;
        protected IEnumerable<Employee> getEmployeesResult
        {
            get
            {
                return _getEmployeesResult;
            }
            set
            {
                if(_getEmployeesResult != value)
                {
                    _getEmployeesResult = value;
                    StateHasChanged();
                }
            }
        }

        Employee _employee;
        protected Employee employee
        {
            get
            {
                return _employee;
            }
            set
            {
                if(_employee != value)
                {
                    _employee = value;
                    StateHasChanged();
                }
            }
        }

        protected override async Task OnInitAsync()
        {
            Northwind.BasePath = UriHelper.GetBaseUri();

            await Task.Run(Load);
        }

        protected async void Load()
        {
            var northwindGetEmployeesResult = await Northwind.GetEmployees(null, null, null, null, null, null, null, null);
                getEmployeesResult = northwindGetEmployeesResult.Data;

            employee = new Employee();
        }

        protected async void Form0Submit(Employee args)
        {
            var northwindCreateEmployeeResult = await Northwind.CreateEmployee(employee);
                UriHelper.NavigateTo("Employees");
        }

        protected async void Button2Click(UIMouseEventArgs args)
        {
            UriHelper.NavigateTo("Employees");
        }
    }
}
