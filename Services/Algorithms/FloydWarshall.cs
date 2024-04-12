using HakatonPIVATON.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HakatonPIVATON.Services.Algorithms
{
    public class FloydWarshallAlgorithm
    {
        public static decimal BackBestRoute(List<CalcBestRouteModel> date, long firstPointId, long secondPointId)
        {
            if(firstPointId < secondPointId)
            {
                long temp;
                temp = firstPointId;
                firstPointId = secondPointId;
                secondPointId = temp;
            }
            var points = new Dictionary<long, long>();
            int numCities = 0;
            foreach (var route in date)
            {
                if (!points.ContainsKey(route.FirstPointId))
                {
                    points[route.FirstPointId] = numCities++;
                }
                if (!points.ContainsKey(route.SecondPointId))
                {
                    points[route.SecondPointId] = numCities++;
                }
            }

            decimal[,] distances = new decimal[numCities, numCities];
            for (int i = 0; i < numCities; i++)
            {
                for (int j = 0; j < numCities; j++)
                {
                    distances[i, j] = (i == j) ? 0 : long.MaxValue;
                }
            }

            foreach (var route in date)
            {
                long fromCity = points[route.FirstPointId];
                long toCity = points[route.SecondPointId];
                distances[fromCity, toCity] = route.Weigh;
            }

            FloydWarshall(distances, numCities);

            long firstPoint = points[firstPointId];
            long secondPoin = points[secondPointId];

            return (distances[firstPoint, secondPoin]);
        }
        static void FloydWarshall(decimal[,] distances, int numCities)
        {
            for (int k = 0; k < numCities; k++)
            {
                for (int i = 0; i < numCities; i++)
                {
                    for (int j = 0; j < numCities; j++)
                    {
                        if (distances[i, k] != int.MaxValue && distances[k, j] != int.MaxValue &&
                            distances[i, k] + distances[k, j] < distances[i, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }
        }
    }
}
