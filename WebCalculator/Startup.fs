namespace WebCalculator

open Views
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open CalculatorController

module private StartupUtil = 
    let webApp =
        choose [
            GET >=> choose [
                route "/" >=> CalculatorController
                ]
            ]
        
open StartupUtil
type Startup() =
    member _.ConfigureServices(services: IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app: IApplicationBuilder) (env: IHostEnvironment) (loggerFactory: ILoggerFactory) =
        app.UseStaticFiles().UseGiraffe(webApp)