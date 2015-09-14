﻿using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireRatingCloud
{
  class DoorData
  {
    public string _id { get; set; }
    public string project_id { get; set; }
    public string level { get; set; }
    public string tag { get; set; }
    public double firerating { get; set; }


    /// <summary>
    /// Constructor to populate instance by 
    /// deserialising the REST GET response.
    /// </summary>
    public DoorData()
    {
    }

    /// <summary>
    /// Constructor from BIM to serialise for
    /// the REST POST or PUT request.
    /// </summary>
    /// <param name="door"></param>
    /// <param name="project_id"></param>
    /// <param name="paramGuid"></param>
    public DoorData(
      Element door,
      string project_id_arg,
      Guid paramGuid )
    {
      Document doc = door.Document;

      _id = door.UniqueId;

      project_id = project_id_arg;

      level = doc.GetElement( door.LevelId ).Name;

      tag = door.get_Parameter( 
        BuiltInParameter.ALL_MODEL_MARK ).AsString();

      firerating = door.get_Parameter( paramGuid )
        .AsDouble();
    }
  }
}
