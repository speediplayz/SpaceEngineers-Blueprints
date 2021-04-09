using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SE_Blueprints
{
    class Blueprint
    {
        string name, directory;
        bool largeShip;
        StreamWriter writer;

        public Blueprint(string name, string directory, bool largeShip)
        {
            this.name = name;
            this.directory = directory;
            this.largeShip = largeShip;

            if (!Directory.Exists(directory + "\\" + name)) Directory.CreateDirectory(directory + "\\" + name);
            writer = new StreamWriter(directory + @"\" + name + "\\bp.sbc");

            long EntityId = RandomEntityId();

            string size = largeShip == true ? "Large" : "Small";

            //writer.WriteLine("");
            writer.WriteLine("<?xml version=\"1.0\"?>");
            writer.WriteLine("<Definitions xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            writer.WriteLine("  <ShipBlueprints>");
            writer.WriteLine("    <ShipBlueprint xsi:type=\"MyObjectBuilder_ShipBlueprintDefinition\">");
            writer.WriteLine("      <Id Type=\"MyObjectBuilder_ShipBlueprintDefinition\" Subtype=\"" + name + "\" />");
            writer.WriteLine("      <DisplayName>speediplayz</DisplayName>");
            writer.WriteLine("      <CubeGrids>");
            writer.WriteLine("        <CubeGrid>");
            writer.WriteLine("          <Subtypename />");
            writer.WriteLine("          <EntityId>" + EntityId.ToString() + "</EntityId>");
            writer.WriteLine("          <PersistentFlags>CastShadows InScene</PersistentFlags>");
            writer.WriteLine("          <Name>" + EntityId.ToString() + "</Name>");
            writer.WriteLine("          <PositionAndOrientation>");
            writer.WriteLine("            <Position x=\"0\" y=\"0\" z=\"0\" />");
            writer.WriteLine("            <Forward x=\"0\" y=\"0\" z=\"0\" />");
            writer.WriteLine("            <Up x=\"0\" y=\"0\" z=\"0\" />");
            writer.WriteLine("            <Orientation>");
            writer.WriteLine("              <X>0</X>");
            writer.WriteLine("              <Y>0</Y>");
            writer.WriteLine("              <Z>0</Z>");
            writer.WriteLine("              <W>0</W>");
            writer.WriteLine("            </Orientation>");
            writer.WriteLine("          </PositionAndOrientation>");
            writer.WriteLine("          <LocalPositionAndOrientation xsi:nil=\"true\" />");
            writer.WriteLine("          <GridSizeEnum>" + size + "</GridSizeEnum>");
            writer.WriteLine("          <CubeBlocks>");
        }

        public void AddBlock(int x, int y, int z, Vector3 color)
        {
            Vector3 hsv = RGBtoHSV(color);

            string Sh = Math.Round(hsv.x, 8).ToString();
            string Ss = Math.Round(hsv.y, 8).ToString();
            string Sv = Math.Round(hsv.z, 8).ToString();

            writer.WriteLine("              <MyObjectBuilder_CubeBlock xsi:type=\"MyObjectBuilder_CubeBlock\">");

            if (largeShip)
            { writer.WriteLine("                <SubtypeName>LargeBlockArmorBlock</SubtypeName>"); }
            else
            { writer.WriteLine("                <SubtypeName>SmallBlockArmorBlock</SubtypeName>"); }

            writer.WriteLine("                <Min x=\"" + x.ToString() + "\" y=\"" + y.ToString() + "\" z=\"" + z.ToString() + "\" />");
            writer.WriteLine("                <ColorMaskHSV x=\"" + Sh + "\" y=\"" + Ss + "\" z=\"" + Sv + "\" />");
            writer.WriteLine("              </MyObjectBuilder_CubeBlock>");
        }

        public void Save()
        {
            writer.WriteLine("          </CubeBlocks>");
            writer.WriteLine("          <DisplayName>" + name + "</DisplayName>");
            writer.WriteLine("          <DestructibleBlocks>true</DestructibleBlocks>");
            writer.WriteLine("          <CreatePhysics>false</CreatePhysics>");
            writer.WriteLine("          <EnableSmallToLargeConnections>false</EnableSmallToLargeConnections>");
            writer.WriteLine("          <IsRespawnGrid>false</IsRespawnGrid>");
            writer.WriteLine("          <LocalCoordSys>0</LocalCoordSys>");
            writer.WriteLine("          <TargetingTargets />");
            writer.WriteLine("        </CubeGrid>");
            writer.WriteLine("      </CubeGrids>");
            writer.WriteLine("      <EnvironmentType>None</EnvironmentType>");
            writer.WriteLine("      <WorkshopId>0</WorkshopId>");
            writer.WriteLine("      <OwnerSteamId>76561198311627380</OwnerSteamId>");
            writer.WriteLine("      <Points>0</Points>");
            writer.WriteLine("    </ShipBlueprint>");
            writer.WriteLine("  </ShipBlueprints>");
            writer.WriteLine("</Definitions>");

            writer.Close();
        }

        private long RandomEntityId()
        {
            string[] nums = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string val = "";

            Random r = new Random(DateTime.Now.Millisecond);

            for(int i = 0; i < 18; i++)
            {
                val += nums[r.Next(0, nums.Length)];
            }

            return long.Parse(val);
        }

        Vector3 RGBtoHSV(Vector3 rgb)
        {
            double h = 0;
            double s = 0;
            double v = 0;
            double min = 0, max = 0, diff = 0, index = 0;

            if (rgb.x == rgb.y && rgb.x == rgb.z)
            {
                index = 0;
                max = rgb.x;
                min = rgb.x;
            }
            else if (rgb.x >= rgb.y && rgb.x >= rgb.z)
            {
                index = 1;
                max = rgb.x;
                min = rgb.y < rgb.z ? rgb.y : rgb.z;
            }
            else if (rgb.y >= rgb.x && rgb.y >= rgb.z)
            {
                index = 2;
                max = rgb.y;
                min = rgb.x < rgb.z ? rgb.x : rgb.z;
            }
            else if (rgb.z >= rgb.y && rgb.z >= rgb.x)
            {
                index = 3;
                max = rgb.z;
                min = rgb.y < rgb.x ? rgb.y : rgb.x;
            }

            diff = max - min;

            switch (index)
            {
                case 0:
                    h = 0;
                    break;
                case 1:
                    h = 60 * ((rgb.y - rgb.z) / diff);
                    break;
                case 2:
                    h = 60 * (2 + (rgb.z - rgb.x) / diff);
                    break;
                case 3:
                    h = 60 * (4 + (rgb.x - rgb.y) / diff);
                    break;
            }
            if (h < 0) h += 360;

            h /= 360;
            s = (((index == 0 ? 0 : (diff / max)) * 2) - 1);
            v = ((max / 255) * 2) - 1;

            return new Vector3(h, s, v);
        }
    }
}
