﻿using KrebsCycleQueuesSimulation.Functions;
using KrebsCycleQueuesSimulation.Structs;
using KrebsSimulationOptimized.Structs;
using System;
using System.Collections.Generic;
using System.IO;

namespace KrebsCycleQueuesSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code allows to perform Krebs Cycle simulation or find Michaelis-Menten constants
            // used in Krebs Cycle simulation

            string output_folder_path = "[path to folder where outputs should be stored]";

            // Modify the object below to set new starting points of Krebs Cycle
            KrebsProducts start_products = KrebsProducts.Default();

            // Pass double array with constants to run simulation/training with your own constants
            KrebsConstants constants = KrebsConstants.DefaultConstants();

            // In case you trained your own weights uncomment the line below to load them
            //KrebsConstants constants = LoadData.LoadCsv("[path to csv weights]")[0];

            // Amplitude of gaussian noise
            double noise_amplitude = 0.03;

            // Modify variable below to set inhibition of certain reactions (default, no reactions)
            KrebsRatesInhibitionConfiguration inhibition = KrebsRatesInhibitionConfiguration.NoInhibition();

            // set how many cells should be simulated 
            int iterations = 2;

            // set how much seconds should be simulated
            int seconds = 3600;

            // Uncomment these lines in order to perform simulation

            Perform.PerformSimulation(
                path_to_output_folder: output_folder_path,
                products: start_products,
                constants: constants,
                noise_amplitude: noise_amplitude,
                inhibition: inhibition,
                iterations: iterations,
                seconds: seconds
                );

            // how many chromosomes should be simulated in one epoch
            int chromosomes_count = 100;

            // how many chromosomes should be taken into the next epoch for reproduction
            int chromosomes_for_reproduction = 10;

            // chance that chromosome will mutate during reproduction (default is 10%)
            double mutation_chance = 0.1;

            // how much impact can be generated by mutation
            double mutation_magnitude = 1.0;
            List<KrebsConstants> start_population = new List<KrebsConstants>() { KrebsConstants.DefaultConstants() };


            // Uncomment these lines in ordet to start training

            //Train.TrainSimulation(
            //    output_folder_path: output_folder_path,
            //    start_products: start_products,
            //    seconds: seconds,
            //    noise_amplitude: noise_amplitude,
            //    chromosomes_count: chromosomes_count,
            //    chromosomes_for_reproduction: chromosomes_for_reproduction,
            //    mutation_chance: mutation_chance,
            //    mutation_magnitude: mutation_magnitude,
            //    start_population: start_population);
        }
    }
}
