﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EPAM_Forum.Entites;

namespace _EPAM_Forum.Intefases.DAL
{
    public interface IUserRoleDAL
    {
        IEnumerable<UserRoleDTO> GetAll();
        UserRoleDTO Get(int id);
        bool Create(UserRoleDTO user_role);
        bool Delete(UserRoleDTO id);
        bool Update(UserRoleDTO user_role);
        bool IsWebUserInRole(string name, string role);
        string[] GetRolesForUser(string web_user_name);
    }
}

//<? xml version="1.0" encoding="utf-8"?>
//<ApplicationInsights xmlns = "http://schemas.microsoft.com/ApplicationInsights/2013/Settings" >

//    < TelemetryModules >

//        < Add Type="Microsoft.ApplicationInsights.DependencyCollector.DependencyTrackingTelemetryModule, Microsoft.AI.DependencyCollector"/>
//		<Add Type = "Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.PerformanceCollectorModule, Microsoft.AI.PerfCounterCollector" >

//            < !--
//      Use the following syntax here to collect additional performance counters:
      
//      <Counters>
//        <Add PerformanceCounter = "\Process(??APP_WIN32_PROC??)\Handle Count" ReportAs="Process handle count" />
//        ...
//      </Counters>
      
//      PerformanceCounter must be either \CategoryName(InstanceName)\CounterName or \CategoryName\CounterName

//      Counter names may only contain letters, round brackets, forward slashes, hyphens, underscores, spaces and dots.
//      You may provide an optional ReportAs attribute which will be used as the metric name when reporting counter data.
//      For the purposes of reporting, metric names will be sanitized by removing all invalid characters from the resulting metric name.

//      NOTE: performance counters configuration will be lost upon NuGet upgrade.

//      The following placeholders are supported as InstanceName:
//        ??APP_WIN32_PROC?? - instance name of the application process  for Win32 counters.
//        ??APP_W3SVC_PROC?? - instance name of the application IIS worker process for IIS/ASP.NET counters.
//        ??APP_CLR_PROC?? - instance name of the application CLR process for .NET counters.
//      -->
//		</Add>
//		<Add Type = "Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing.DiagnosticsTelemetryModule, Microsoft.ApplicationInsights" />

//        < Add Type= "Microsoft.ApplicationInsights.WindowsServer.DeveloperModeWithDebuggerAttachedTelemetryModule, Microsoft.AI.WindowsServer" />

//        < Add Type= "Microsoft.ApplicationInsights.Web.RequestTrackingTelemetryModule, Microsoft.AI.Web" />

//        < Add Type= "Microsoft.ApplicationInsights.Web.ExceptionTrackingTelemetryModule, Microsoft.AI.Web" />

//    </ TelemetryModules >

//    < TelemetryChannel Type= "Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel.ServerTelemetryChannel, Microsoft.AI.ServerTelemetryChannel" />
//< !--
//    Learn more about Application Insights configuration with ApplicationInsights.config here: 
//    http://go.microsoft.com/fwlink/?LinkID=513840

//    Note: If not present, please add <InstrumentationKey>Your Key</InstrumentationKey> to the top of this file.
//  -->
//<TelemetryInitializers>
//<Add Type = "Microsoft.ApplicationInsights.WindowsServer.AzureRoleEnvironmentTelemetryInitializer, Microsoft.AI.WindowsServer" />
//< Add Type= "Microsoft.ApplicationInsights.WindowsServer.DomainNameRoleInstanceTelemetryInitializer, Microsoft.AI.WindowsServer" />
//< Add Type= "Microsoft.ApplicationInsights.WindowsServer.BuildInfoConfigComponentVersionTelemetryInitializer, Microsoft.AI.WindowsServer" />
//< Add Type= "Microsoft.ApplicationInsights.WindowsServer.DeviceTelemetryInitializer, Microsoft.AI.WindowsServer" />
//< Add Type= "Microsoft.ApplicationInsights.Web.SyntheticTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.ClientIpHeaderTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.UserAgentTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.OperationNameTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.OperationIdTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.UserTelemetryInitializer, Microsoft.AI.Web" />
//< Add Type= "Microsoft.ApplicationInsights.Web.SessionTelemetryInitializer, Microsoft.AI.Web" />
//</ TelemetryInitializers >
//< !--
//    Learn more about Application Insights configuration with ApplicationInsights.config here: 
//    http://go.microsoft.com/fwlink/?LinkID=513840

//    Note: If not present, please add <InstrumentationKey>Your Key</InstrumentationKey> to the top of this file.
//  --></ApplicationInsights>