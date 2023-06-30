using FitnessCenter_EF.API.Validation.Instructor;
using FitnessCenter_EF.API.Validation.Subscription;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Instructor;
using FitnessCenter_EF.BLL.DTOs.Subscription;
using FitnessCenter_EF.BLL.Services;
using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
using FitnessCenter_EF.DAL.Helpers;
using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessCenter_EF.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
