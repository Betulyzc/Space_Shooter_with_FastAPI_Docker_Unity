from sqlalchemy.orm import Session
from models import Score
from schemas import ScoreCreate

def save_score(score:ScoreCreate,db:Session,):
    new_score=Score(**score.model_dump()) #converts the incoming Pydantic data into a model object
    db.add(new_score)
    db.commit()
    db.refresh(new_score) 
    return new_score

def get_scores(db:Session):
    return db.query(Score).order_by(Score.score.desc()).all()
    