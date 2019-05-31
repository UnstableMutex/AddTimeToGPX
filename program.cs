            XDocument d = XDocument.Load("test.gpx");

            var startDate = DateTime.Parse("2019-05-30 20:05");

            XElement m = new XElement("metadata", new XElement("time", startDate.ToString("s")));
            var gpx = d;

            var f = gpx.Elements().First();
            var ns = "http://www.topografix.com/GPX/1/1";
            var n = XName.Get("trk", ns);
            var fn = gpx.DescendantNodes().First() as XElement;

            fn.AddFirst(m);


            var trk = gpx.Descendants(n);
            //var a = gpx.Elements(n);


            var trkseg = trk.Elements(XName.Get("trkseg", ns)).First() as XElement;
            var pts = trkseg.Elements((XName.Get("trkpt", ns)));
            var dt = startDate;
            foreach (var item in pts)
            {

                var x = item as XElement;
                var t = new XElement(XName.Get("time", ns), dt.ToString("s"));
                x.Add(t);
                dt = dt.AddSeconds(1);
            }


            File.Delete("test1.gpx");
            d.Save("test1.gpx");
