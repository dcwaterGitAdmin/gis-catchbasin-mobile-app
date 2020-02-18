using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel.Helper
{
    public class AddressParser
    {
        private static string[] arrStateNames = {
        "washington",
        "montana",
        "maine",
        "north dakota",
        "south dakota",
        "wyoming",
        "wisconsin",
        "idaho",
        "vermont",
        "minnesota",
        "oregon",
        "new hampshire",
        "iowa",
        "massachusetts",
        "nebraska",
        "new york",
        "pennsylvania",
        "connecticut",
        "rhode island",
        "new jersey",
        "indiana",
        "nevada",
        "utah",
        "california",
        "ohio",
        "illinois",
        "district of columbia",
        "delaware",
        "west virginia",
        "maryland",
        "colorado",
        "kentucky",
        "kansas",
        "virginia",
        "missouri",
        "arizona",
        "oklahoma",
        "north carolina",
        "tennessee",
        "texas",
        "new mexico",
        "alabama",
        "mississippi",
        "georgia",
        "south carolina",
        "arkansas",
        "louisiana",
        "florida",
        "michigan",
        "hawaii",
        "alaska",
        "washington, dc",
        "washington dc"

    };
        private static string[] arrStateAbbrevs = {
        "WA",
        "MT",
        "ME",
        "ND",
        "SD",
        "WY",
        "WI",
        "ID",
        "VT",
        "MN",
        "OR",
        "NH",
        "IA",
        "MA",
        "NE",
        "NY",
        "PA",
        "CT",
        "RI",
        "NJ",
        "IN",
        "NV",
        "UT",
        "CA",
        "OH",
        "IL",
        "DC",
        "DE",
        "WV",
        "MD",
        "CO",
        "KY",
        "KS",
        "VA",
        "MO",
        "AZ",
        "OK",
        "NC",
        "TN",
        "TX",
        "NM",
        "AL",
        "MS",
        "GA",
        "SC",
        "AR",
        "LA",
        "FL",
        "MI",
        "HI",
        "AK",
        "DC",
        "DC"

    };
        //* 
        // * Put most frequenly used names upfront as we are using brute force to search for the name !!! 
        // 

        private static string[] streetTypes = {
        "RD",
        "ST",
        "STREET",
        "ROAD",
        "AV",
        "AVE",
        "AVENUE",
        "DR",
        "DRIVE",
        "RT",
        "RTE",
        "ALY",
        "ANX",
        "ARC",
        "BCH",
        "BG",
        "BLF",
        "BLFS",
        "BLVD",
        "BND",
        "BOULEVARD",
        "BR",
        "BRG",
        "BRK",
        "BRKS",
        "BTM",
        "BYP",
        "BYU",
        "CIR",
        "CIRCLE",
        "CIRS",
        "CLB",
        "CLF",
        "CLFS",
        "CMN",
        "CMNS",
        "COR",
        "CORS",
        "COURT",
        "CP",
        "CPE",
        "CRES",
        "CRK",
        "CRSE",
        "CRST",
        "CSWY",
        "CT",
        "CTR",
        "CTS",
        "CURV",
        "CV",
        "CVS",
        "CYN",
        "DL",
        "DM",
        "DRS",
        "DV",
        "EST",
        "ESTS",
        "EXPY",
        "EXT",
        "FALL",
        "FLD",
        "FLDS",
        "FLS",
        "FLT",
        "FLTS",
        "FRD",
        "FRG",
        "FRK",
        "FRKS",
        "FRST",
        "FRY",
        "FT",
        "FWY",
        "GDN",
        "GDNS",
        "GLN",
        "GLNS",
        "GRN",
        "GRNS",
        "GRV",
        "GRVS",
        "GTWY",
        "HBR",
        "HL",
        "HLS",
        "HOLW",
        "HTS",
        "HVN",
        "HWY",
        "INLT",
        "IS",
        "ISLE",
        "ISS",
        "JCT",
        "KNL",
        "KNLS",
        "KY",
        "KYS",
        "LAND",
        "LCK",
        "LCKS",
        "LDG",
        "LF",
        "LGT",
        "LGTS",
        "LK",
        "LKS",
        "LN",
        "LNDG",
        "LOOP",
        "MALL",
        "MDW",
        "MDWS",
        "MEWS",
        "ML",
        "MLS",
        "MNR",
        "MNRS",
        "MSN",
        "MT",
        "MTN",
        "MTNS",
        "MTWY",
        "NCK",
        "OPAS",
        "ORCH",
        "OVAL",
        "OVLK",
        "PARK",
        "PASS",
        "PATH",
        "PIKE",
        "PKWY",
        "PL",
        "PLN",
        "PLNS",
        "PLZ",
        "PNE",
        "PNES",
        "PR",
        "PRT",
        "PSGE",
        "PT",
        "PTS",
        "RADL",
        "RAMP",
        "RDG",
        "RDGS",
        "RDS",
        "RIV",
        "RNCH",
        "ROW",
        "RPDS",
        "RST",
        "RUE",
        "RUN",
        "SHL",
        "SHLS",
        "SHR",
        "SHRS",
        "SKWY",
        "SMT",
        "SPG",
        "SPGS",
        "SPUR",
        "SQ",
        "STA",
        "STRA",
        "STRM",
        "STS",
        "TER",
        "TPKE",
        "TRAK",
        "TRCE",
        "TRFY",
        "TRL",
        "TRLR",
        "TRWY",
        "TUNL",
        "UN",
        "UPAS",
        "VIA",
        "VIS",
        "VL",
        "VLG",
        "VLY",
        "VW",
        "VWS",
        "WALK",
        "WALL",
        "WAY",
        "WAYS",
        "WL",
        "WLS",
        "XING",
        "XRD",
        "XRDS"

    };
        private static string[] streetPrefix = {
        "E",
        "N",
        "NE",
        "NW",
        "S",
        "SE",
        "SW",
        "W"

    };
        private static string[] streetSuffix = {
        "E",
        "N",
        "NE",
        "NW",
        "S",
        "SE",
        "SW",
        "W"
    };
        private string streetNumber = "";
        private string Prefix = "";
        private string streetName = "";
        private string streetType = "";
        private string Suffix = "";
        private string city = "";
        private string zip = "";
        private string state = "";
        private string stateAbbreviation = "";

        private string stateInput = "";

        //* 
        // * Parse the place string name. Find address, zip, city, and state. 
        // 


        public AddressParser(string text)
        {
            if (text == null || text.Length == 0)
            {
                return;
            }
            //Parse the Address for each piece
            string[] tmpParts = parseForDelimiters(text.Trim(), " ");

            streetName = text.Trim();
            for (int i = 0; i <= tmpParts.Length - 1; i++)
            {
                if (isNumber(tmpParts[i]))
                {
                    streetNumber = tmpParts[i];
                }
                else if (isStreetPrefix(tmpParts[i]))
                {
                    Prefix = tmpParts[i];
                }
                else if (isStreetSuffix(tmpParts[i]))
                {
                    Suffix = tmpParts[i];
                }
                else if (isStreetType(tmpParts[i]))
                {
                    streetType = tmpParts[i];
                }
                else if (isZip(tmpParts[i]))
                {
                    zip = tmpParts[i];

                }
                else
                {
                    if (!string.IsNullOrEmpty(streetName))
                    {
                        streetName = tmpParts[i];
                    }

                }
            }


        }

        //* 
        // * Parse string into ArrayList. Divide by delimiter. 
        // 

        private string[] parseForDelimiters(string name, string delimiter)
        {

            string st = name;
            string[] parts = st.Split(Convert.ToChar(delimiter));

            int i = 0;


            for (i = 0; i <= parts.Length - 1; i++)
            {
                parts[i] = Convert.ToString(parts[i].Trim());
            }

            return parts;

        }
        //* 
        // * Is the text a zip code? 
        // 

        private bool isZip(string text)
        {

            // is it 5 characters in length? 
            if (text.Length == 5)
            {
                // is it numeric 
                try
                {
                    int.Parse(text);
                    //.[Integer]()
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else if (text.Length == 10 && text.IndexOf("-") == 5)
            {
                // is it 10 characters in length 
                string first = text.Substring(0, 5);
                string last = text.Substring(6, 10);
                // is it numeric 
                try
                {
                    int.Parse(first);
                    //).[Integer]()
                    try
                    {
                        int.Parse(last);
                        //.[Integer]()
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //* 
        // * Is the text a state ? 
        // 

        private bool isState(string[] part, int count)
        {
            bool found = false;
            string text = "";
            for (int k = 0; k <= 2; k++)
            {
                if (part.Length > count + k)
                {
                    if (text.Length > 0)
                    {
                        text += " ";
                    }
                    text += part[count + k];
                    for (int i = 0; i <= arrStateNames.Length - 1; i++)
                    {
                        if (text.ToLower().Equals((string)arrStateNames[i]))
                        {
                            stateAbbreviation = arrStateAbbrevs[i];
                            stateInput = text;
                            found = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    if (!found)
                    {
                        for (int i = 0; i <= arrStateAbbrevs.Length - 1; i++)
                        {
                            if (text.ToUpper().Equals((string)arrStateAbbrevs[i]))
                            {
                                stateAbbreviation = arrStateAbbrevs[i];
                                stateInput = text;
                                found = true;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return found;
        }

        //* 
        // * Is the text a street prefix ? 
        // 

        private bool isStreetPrefix(string text)
        {

            for (int i = 0; i <= streetPrefix.Length - 1; i++)
            {
                if (text.ToUpper().Equals((string)streetPrefix[i]))
                {
                    return true;
                }
            }
            return false;
        }

        //* 
        // * Is the text a street suffix ? 
        // 

        private bool isStreetSuffix(string text)
        {

            for (int i = 0; i <= streetSuffix.Length - 1; i++)
            {
                if (text.ToUpper().Equals((string)streetSuffix[i]))
                {
                    return true;
                }
            }
            return false;
        }

        //* 
        // * Is the text a street type ? 
        // 

        private bool isStreetType(string text)
        {

            for (int i = 0; i <= streetTypes.Length - 1; i++)
            {
                if (text.ToUpper().Equals((string)streetTypes[i]))
                {
                    return true;
                }
            }
            return false;
        }

        //* 
        // * Is the text a appartment number 
        // 

        private bool isAppartmentNumber(string text)
        {

            if (text.StartsWith("#"))
            {
                return true;
            }
            return false;
        }

        //* 
        // * Is the text a number? 
        // 

        private bool isNumber(string text)
        {

            try
            {
                int.Parse(text);
                //parseInt(text).[integer]()
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public string getStreetName()
        {
            return this.streetName;
        }
        public string getStreetNumber()
        {
            return this.streetNumber;
        }
        public string getStreetType()
        {
            return this.streetType;
        }

        public string getStreetSuffix()
        {
            return this.Suffix;
        }
        public string getStreetPrefix()
        {
            return this.Prefix;
        }
        //* 
        // * Get the city. 
        // 

        public string getCity()
        {
            return this.city;
        }

        //* 
        // * Get the state. 
        // 

        public string getState()
        {
            return this.state;
        }

        //* 
        // * Get the zip. 
        // 

        public string getZip()
        {
            return this.zip;
        }

    }

}
