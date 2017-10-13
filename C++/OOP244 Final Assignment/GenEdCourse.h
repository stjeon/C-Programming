#include "Course.h"
#include "general.h"

namespace sict{
	class GenEdCourse :public Course{
		int langlevel_;
	public:
		GenEdCourse();
		GenEdCourse(const char* code, const char* title, int credits, int study, const int lang);
		GenEdCourse(const char* code, const char* title, int credits, int study);
		int getLangLevel() const;
		void setLangLevel(int value);
		void display(ostream& pout);//derived from base class
		fstream& GenEdCourse::store(fstream& fileStream, bool addNewLine) const; //derived from Streamable class
		ostream& GenEdCourse::display(ostream& os) const; //derived display function from Streamable
		istream& GenEdCourse::read(istream& istr); //derived istream function from Streamable
		fstream& GenEdCourse::load(fstream& fileStream); //derived load function from Streamable
	};
	std::ostream& operator<<(std::ostream& pout, GenEdCourse& a);
}
