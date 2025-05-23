from fastapi import HTTPException 
from sqlalchemy import String
from sqlalchemy.orm import Session
from models import Score
from schemas import ScoreCreate
import schemas


def save_score(score: ScoreCreate, db: Session):
    existing_score = db.query(Score).filter(Score.player_name == score.player_name).first()
    if existing_score:
        existing_score.score = score.score
        db.commit()
        db.refresh(existing_score)
        return existing_score
    else:
        new_score = Score(**score.model_dump())
        db.add(new_score)
        db.commit()
        db.refresh(new_score)
        return new_score
    
def get_scores(db:Session):
    return db.query(Score).order_by(Score.score.desc()).all()
    
def delete_score_by_username(username:str,db:Session):
    deleted=db.query(Score).filter(Score.player_name==username).first()
    if deleted != None:
        db.delete(deleted)
        db.commit()
        return {"message": f"Player '{username}' deleted."}
    else:
        raise HTTPException(status_code=404, detail="Player not found.")

def delete_score_by_id(id: int, db: Session):
    deleted = db.query(Score).filter(Score.id == id).first()
    if deleted != None :
        db.delete(deleted)
        db.commit()
        return {"message": f"Player '{id} - {deleted.player_name}' deleted."}
    else:
        raise HTTPException(status_code=404, detail="Player not found.")
    

def check_username(username:str, db:Session):
    user = db.query(Score).filter(Score.player_name == username).first()
    if user:
        return schemas.UsernameCheckResponse(exists=True)
    else:
        return schemas.UsernameCheckResponse(exists=False)

