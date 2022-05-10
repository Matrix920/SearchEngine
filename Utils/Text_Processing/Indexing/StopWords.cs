using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Text_Processing.Indexing
{
    public class StopWords
    {
        public string remove(string item)
        {
            string result="";

            item = item.Trim().ToString().ToLower();

            if (!stopWordsList.Contains(item))
            {
                result += item;
            }
            return result;
        }

        List<String> stopWordsList = new List<String>
        {
            "I" ,"a" ,
             "an" ,"as" ,
             "at" ,"by" ,
             "he" ,"his" ,
             "me" ,"or" ,
             "thou" ,"us" ,
             "who" ,"against" ,
             "amid" ,"amidst" ,
             "among" ,"amongst" ,
             "and" ,"anybody" ,
             "anyone" ,"because" ,
             "beside" ,"circa" ,
             "despite" ,"during" ,
             "everybody" ,"everyone" ,
             "for" ,"from" ,
             "her" ,"hers" ,
             "herself" ,"him" ,
             "himself" ,"hisself" ,
             "idem" ,"if" ,
             "into" ,"it" ,
             "its" ,"itself" ,
             "myself" ,"nor" ,
             "of" ,"onself" ,
             "onto" ,"our" ,
             "ourself" ,"ourserlves" ,
             "per" ,"she" ,
             "since" ,"than" ,
             "that" ,"she" ,
             "thee" ,"theirs" ,
             "them" ,"themselves" ,
             "thine" ,"they" ,
             "this" ,"thyself" ,
             "to" ,"tother" ,
             "toward" ,"towards" ,
             "until" ,"unless" ,
             "upon" ,"versus" ,
             "via" ,"we" ,
             "what" ,"whatall" ,
             "whereas" ,"which" ,
             "whichever" ,"whichsover" ,
             "whoever" ,"whom" ,
             "whomever" ,"whomso" ,
             "whomsoever" ,"you-all" ,
             "whose" ,"yours" ,
             "whosoever" ,"yourself" ,
             "with" ,"yourselves" ,
             "without" ,"aboard" ,
             "ye" ,"about" ,
             "you" ,"above" ,
             "alongside" ,"across" ,
             "although" ,"after" ,
             "another" ,"all" ,
             "anti" ,"along" ,
             "any" ,"behind" ,
             "anything" ,"below" ,
             "around" ,"beneath" ,
             "astride" ,"besides" ,
             "aught" ,"between" ,
             "bar" ,"beyond" ,
             "barring" ,"both" ,
             "before" ,"but" ,
             "concerning" ,"considering" ,
             "down" ,"each" ,
             "either" ,"enough" ,
             "except" ,"excepting" ,
             "excluding" ,"few" ,
             "fewer" ,"following" ,
             "ilk" ,"in" ,
             "like" ,"including" ,
             "under" ,"underneath" ,
             "unlike" ,"up" ,
             "various" ,"vis-a-vis" ,
             "whatever" ,"whatsoever" ,
             "when" ,"wherewith" ,
             "wherewithal" ,"while" ,
             "within" ,"worth" ,
             "yet" ,"yon" ,
             "is" ,"the" ,
             "has" ,"also" ,
             "been" ,"being" ,
             "are" ,"these" ,
             "yonder",
             "many" ,"inside" ,
             "mine" ,"more" ,
             "minus" ,"naught" ,
             "most" ,"near" ,
             "neither" ,"nobody" ,
             "none" ,"nothing" ,
             "notwithstanding" ,"opposite" ,
             "on" ,"off" ,
             "other" ,"otherwise" ,
             "over" ,"outside" ,
             "past" ,"own" ,
             "pending" ,"round" ,
             "plus" ,"save" ,
             "regarding" ,"self" ,
             "several" ,"so" ,
             "some" ,"somebody" ,
             "someone" ,"something" ,
             "somewhat" ,"such" ,
             "suchlike" ,"sundry" ,
             "there" ,"though" ,
             "through" ,"throughout" ,
             "till" ,"twain"
             
        };
    }
}
