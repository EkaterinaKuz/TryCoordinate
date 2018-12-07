using System;


namespace TryCoordinate
{
    public class Point
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public const double Radius = 6371; // The radius of the Earth in kilometers.

        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static double DistanceBetweenToPoint(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            try
            {
                if (!IsCorrectPoints(startLatitude, startLongitude, endLatitude, endLongitude))
                {
                    return 0;
                }

                var deltaLatitude = ToRadian(endLatitude - startLatitude);
                var deltaLongitude = ToRadian(endLongitude - startLongitude);

                var a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                        Math.Cos(ToRadian(startLatitude)) * Math.Cos(ToRadian(endLatitude)) *
                        Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);

                var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                return Radius * angle;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex);
                return 0;
            }
        }

        public double DistanceBetweenToPoints(Point endPoint)
        {
            if (endPoint == null)
            {
                return 0;
            }

            return DistanceBetweenToPoint(Latitude, Longitude, endPoint.Latitude, endPoint.Longitude);
        }


        private static bool IsCorrectPoints(double startLatitude, double endLatitude, double startLongitude, double endLongetude)
        {
            if ( (Math.Abs(startLatitude) <=90d) && (Math.Abs(startLongitude) <=180d) )
            {
                if ( (Math.Abs(endLatitude) <= 90d) && (Math.Abs(endLongetude) <= 180d) )
                {
                    return true;
                }
            }
            return false;
        }



        private static double ToRadian(double deg)
        {
            if (deg == 0d)
            {
                return 0d;
            }

            return deg * Math.PI / 180;
        }

    }
}
