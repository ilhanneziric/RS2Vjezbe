﻿using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public abstract class BaseState
    {
        public Database.Proizvodi CurrentEntity { get; set; }
        public string CurrentState { get; set; }
        public eProdajaContext Context { get; set; }

        public virtual Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            throw new Exception("not allowed");
        }

        public virtual void Update(ProizvodiUpdateRequest request)
        {
            throw new Exception("not allowed");
        }

        public virtual void Activate()
        {
            throw new Exception("not allowed");
        }

        public virtual void Hide()
        {
            throw new Exception("not allowed");
        }

        public virtual void Delete()
        {
            throw new Exception("not allowed");
        }

        public static BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return new InitialProductState();
                case "draft":
                    return new DraftProductState();
                case "active":
                    return new ActiveProductState();
                default:
                    throw new Exception("not supported");
            }
        }
    }
}
